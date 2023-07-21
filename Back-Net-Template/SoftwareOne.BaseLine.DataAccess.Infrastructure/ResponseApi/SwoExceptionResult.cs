using SoftwareOne.BaseLine.ApplicationTexts;
using SoftwareOne.BaseLine.Core.ExtensionMethods;

namespace SoftwareOne.BaseLine.Middleware.ResponseApi
{
    /// <summary>
    /// 
    /// </summary>
    public enum CategoryException
    {
        [LocalizedDescription("General", typeof(ResourceTexts))]
        General,
        [LocalizedDescription("Database", typeof(ResourceTexts))]
        DataBase,
        [LocalizedDescription("Business", typeof(ResourceTexts))]
        BusinessException,
        [LocalizedDescription("Validation", typeof(ResourceTexts))]
        Validation,
        [LocalizedDescription("Security", typeof(ResourceTexts))]
        Security
    }

    /// <summary>
    /// 
    /// </summary>
    internal class SwoExceptionResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string CodeException { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public CategoryException CategoryException { get; set; } = CategoryException.General;

        /// <summary>
        /// 
        /// </summary>
        public string TextCategoryException => CategoryException.GetEnumDescription();

        /// <summary>
        /// 
        /// </summary>
        public List<string> Messages { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public string TechnicalMessage { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string Exception { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }
    }
}