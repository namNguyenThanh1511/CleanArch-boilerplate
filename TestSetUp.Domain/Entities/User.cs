
using TestSetup.Domain.Exception;

namespace TestSetup.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Identifier { get; set; } = string.Empty;

        public string? Avatar { get; set; }

        public Role UserRole { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public enum Role
        {
            Admin = 1,
            User = 2
        }

        // Navigation property - NOT a database column
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        // Business Logic Methods (không có validation)
        public void Activate()
        {
            if (IsActive)
                throw new BusinessRuleViolationException("User is already active");

            IsActive = true;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void Deactivate()
        {
            if (!IsActive)
                throw new BusinessRuleViolationException("User is already inactive");

            IsActive = false;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void ChangeRole(Role newRole)
        {
            if (UserRole == newRole)
                throw new BusinessRuleViolationException($"User already has role {newRole}");

            UserRole = newRole;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void CheckCanLogin()
        {
            if (!IsActive)
                throw new UserInactiveException();
        }

        public bool IsAdult()
        {
            var age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.DayOfYear > DateTime.Today.DayOfYear)
                age--;

            return age >= 18;
        }
    }
}
