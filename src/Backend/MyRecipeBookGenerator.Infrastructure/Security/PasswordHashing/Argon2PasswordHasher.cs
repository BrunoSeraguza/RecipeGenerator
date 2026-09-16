using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using MyRecipeBookGenerator.Domain.Security.PasswordHasher;

namespace MyRecipeBookGenerator.Infrastructure.Security.PasswordHashing;

internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    private const int DEGREE_OF_PARALLELISM = 1;
    private const int ITERATIONS = 2;
    private const int MEMORY_SIZE = 10 * 1024; //20MB
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;

    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
        var hash = HashPassword(password, salt);
        var combinedBytes = new byte[hash.Length + salt.Length];

        salt.CopyTo(combinedBytes, 0);
        hash.CopyTo(combinedBytes, index: salt.Length);

        return Convert.ToBase64String(combinedBytes);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        var combinedBytes = Convert.FromBase64String(passwordHash);

        var salt = new byte[SALT_SIZE];
        var hash = new byte[HASH_SIZE];
        ///  public static void Copy(Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length)
        Array.Copy(combinedBytes, salt, SALT_SIZE);
        Array.Copy(combinedBytes, SALT_SIZE, hash, 0, HASH_SIZE);

        var newHash = HashPassword(password, salt);

        return  CryptographicOperations.FixedTimeEquals(hash, newHash);
    }

    public byte[] HashPassword(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var hashAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALLELISM,
            Iterations = ITERATIONS, // quantas iteracoes vai fazer em cima do algoritimo gerado
            MemorySize = MEMORY_SIZE,
            Salt = salt // 'concatenacao' adicional em cima da senha gerada pelo algoritimo
        };

        return hashAlgorithm.GetBytes(HASH_SIZE);
    }

}
