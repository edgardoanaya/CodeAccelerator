using static SoftwareOne.BaseLine.Core.Enumerations.SwoEnumApplication;

namespace SoftwareOne.BaseLine.Core.ProcessServicesApplication
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProcessServicesApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="codeTransaccional"></param>
        /// <param name="tipoError"></param>
        /// <param name="textTitle"></param>
        /// <param name="descripcionError"></param>
        void CreateBusinessLogApp(int idUser, int codeTransaccional,
                                  TypeError tipoError,
                                  string textTitle, string descripcionError);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="codeTransaccional"></param>
        /// <param name="tipoError"></param>
        /// <param name="textTitle"></param>
        /// <param name="ex"></param>
        void CreateBusinessLogApp(int idUser, int codeTransaccional,
                                  TypeError tipoError,
                                  string textTitle, Exception ex);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="idUser"></param>
        /// <param name="objectActual"></param>
        /// <param name="objectPreview"></param>
        /// <param name="typeAudit"></param>
        void CreateAuditAppAsync<T>(string entity,
                               T objectActual, T? objectPreview,
                               TypeAudit typeAudit)
            where T : class, Entities.IEntity;
    }
}