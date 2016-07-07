namespace aspnet_core.models
{
    /// <summary>
    /// Course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Course name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// Course level
        /// </summary>
        /// <returns></returns>
        public int Level { get; set; }
    }
}