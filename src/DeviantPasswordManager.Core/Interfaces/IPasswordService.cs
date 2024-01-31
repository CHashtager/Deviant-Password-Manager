using Ardalis.Result;

namespace DeviantPasswordManager.Core.Interfaces;

public interface IPasswordService
{
  public string Encrypt(string plainPassword, string passPhrase);
  public string Decrypt(string encryptedPassword, string passPhrase);
  public Task<Result> DeletePassword(int passwordId);
}
