using Physiqube.Common.Types;
using Physiqube.Domain.Activities;

namespace Physiqube.Domain.Athletes;

public class Athlete
{
    public Athlete()
    {
        Activities = new List<Activity>();
    }
    public Guid Id { get; set; }
    public required string IdentityId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string EmailAddress { get; set; }
    public Uri? ProfilePhoto { get; set; }
    public Location? Location { get; set; }
    public ProfileSettings? ProfileSettings { get; set; }
    public Gender Gender { get; set; }
    public Height? Height { get; set; }
    public Weight? Weight { get; set; }
    public ICollection<Activity> Activities { get; set; }
    
    // Factory method
    public static Athlete Create(string identityId, string firstName, string lastName, string emailAddress)
    {
        return new Athlete
        {
            IdentityId = identityId,
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = emailAddress
        };
    }
}