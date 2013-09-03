namespace Butzelaar.Webshop.Database.Entities.Security
{
    /// <summary>
    /// The userprofile entity
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
    }
}
