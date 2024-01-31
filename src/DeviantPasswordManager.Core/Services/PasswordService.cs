using System.Security.Cryptography;
using System.Text;
using Ardalis.Result;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.PasswordAggregate.Events;
using DeviantPasswordManager.Core.Interfaces;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace DeviantPasswordManager.Core.Services;

public class PasswordService(
  IRepository<Password> repository,
  IMediator mediator,
  ILogger<PasswordService> logger) : IPasswordService
{
  private byte[] Process(bool encrypt, string keyMaterial, byte[] input)
  {
    var keyMaterialBytes = Encoding.UTF8.GetBytes(keyMaterial);
    var digest = new Sha256Digest();
    digest.BlockUpdate(keyMaterialBytes, 0, keyMaterialBytes.Length);
    var keyBytes = new byte[digest.GetDigestSize()];
    digest.DoFinal(keyBytes, 0);

    var cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");
    cipher.Init(encrypt, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", keyBytes), new byte[16]));
    return cipher.DoFinal(input);
  }

  public string Encrypt(string plainPassword, string passPhrase)
  {
    var plaintextBytes = Encoding.UTF8.GetBytes(plainPassword); // UTF-8 encode
    var ciphertextBytes = Process(true, passPhrase, plaintextBytes);
    return Convert.ToBase64String(ciphertextBytes).Replace("+", "-").Replace("/", "_"); // Base64url encode
  }

  public string Decrypt(string encryptedPassword, string passPhrase)
  {
    var ciphertextBytes =
      Convert.FromBase64String(encryptedPassword.Replace("-", "+").Replace("_", "/")); // Base64url decode
    var decryptedBytes = Process(false, passPhrase, ciphertextBytes);
    return Encoding.UTF8.GetString(decryptedBytes); // UTF-8 decode
  }

  public async Task<Result> DeletePassword(int password)
  {
    logger.LogInformation("Deleting Password {password}", password);
    var aggregateToDelete = await repository.GetByIdAsync(password);
    if (aggregateToDelete == null) return Result.NotFound();

    await repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new PasswordDeletedEvent(password);
    await mediator.Publish(domainEvent);
    return Result.Success();
  }
}
