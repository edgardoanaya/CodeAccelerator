using SoftwareOne.BaseLine.Core.DataAccess;
using SoftwareOne.BaseLine.Core.RequestDto;
using SoftwareOne.BaseLine.Core.ExtensionMethods;

namespace SoftwareOne.BaseLine.Core.SqlServer
{
    public abstract partial class BaseRepositoryDataAccess<T>
    {
        /// <summary>
        /// Constant that contains the default records per page.
        /// </summary>
        private const int RECORDS_PER_PAGE = 20;

        public IMainDataAccessContext Contexto { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IQuery"></param>
        /// <param name="parameterOfList"></param>
        /// <returns></returns>
        public static SwoPaginatedList<T> ConfigParametersPaginated(IQueryable<T> IQuery, SwoParameterOfQuery<T> parameterOfList)
        {
            IQuery = ConfigParameters(IQuery, parameterOfList);

            var oToList = new SwoPaginatedList<T>(IQuery);
            if (parameterOfList.IsNotNull()) { 
                oToList.Paged = parameterOfList.TextPag; 
            }
            return oToList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IQuery"></param>
        /// <param name="parameterOfList"></param>
        /// <returns></returns>
        public static IQueryable<T> ConfigParameters(IQueryable<T> IQuery, SwoParameterOfQuery<T>? parameterOfList)
        {
            if (parameterOfList != null &&  parameterOfList.IsNotNull())
            {
                if (parameterOfList.OrderByDynamic.Item1.IsValid())
                {
                    IQuery = IQuery.OrderByDynamic(parameterOfList.OrderByDynamic.Item1, parameterOfList.OrderByDynamic.Item2);
                }
                else 
                { 
                    if (parameterOfList.OrderBy != null && parameterOfList.OrderBy.IsNotNull()) 
                    { 
                        IQuery = parameterOfList.OrderBy(IQuery); 
                    } 
                }

                if (parameterOfList.Filter != null && parameterOfList.Filter.IsNotNull()) 
                { 
                    IQuery = IQuery.Where(parameterOfList.Filter); 
                }

                if (parameterOfList.Skip > -1) 
                { 
                    parameterOfList.MaxCount = IQuery.LongCount(); 
                }

                if (parameterOfList.Take > -1)
                {
                    if (parameterOfList.Skip > -1) 
                    { 
                         IQuery = IQuery.Skip(parameterOfList.Skip); 
                    }
                    IQuery = IQuery.Take(parameterOfList.Take);
                }
                else
                {
                    if (parameterOfList.Skip > -1)
                    {
                        if (parameterOfList.Take < 0)
                        { 
                            parameterOfList.Take = RECORDS_PER_PAGE; 
                        }

                        if (parameterOfList.Skip > -1) 
                        { 
                            IQuery = IQuery.Skip(parameterOfList.Skip); 
                        }
                        IQuery = IQuery.Take(parameterOfList.Take);
                    }
                }
            }
            return IQuery;
        }
    }
}