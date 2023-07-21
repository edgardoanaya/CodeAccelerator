using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using SoftwareOne.BaseLine.Core.Exceptions;
using SoftwareOne.BaseLine.ApplicationTexts;
using System.Security.Authentication;

namespace SoftwareOne.BaseLine.Middleware.ResponseApi
{
    internal class SwoExceptionHelper
    {
        public static SwoExceptionResult HandleException(Exception exception)
        {
            var errorResult = new SwoExceptionResult
            {
                Source = exception.TargetSite?.DeclaringType?.FullName ?? string.Empty,
                Exception = exception.Message.Trim(),
                CodeException = Guid.NewGuid().ToString()
            };

            if (exception is not Core.Exceptions.SwoCustomException && exception.InnerException != null)
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
            }

            switch (exception)
            {
                case SwoCustomException e:
                    if(exception.GetType() ==  typeof(SwoDomainValidationException)) {
                        errorResult.CategoryException = CategoryException.Validation;
                    } else  if(exception.GetType() ==  typeof(SwoUnauthorizedException) || exception.GetType() == typeof(SwoForbiddenException)) {
                        errorResult.CategoryException = CategoryException.Security;
                    } else {
                        errorResult.CategoryException = CategoryException.BusinessException;
                    }

                    errorResult.StatusCode = (int)e.StatusCode;
                    if (e.ErrorMessages is not null)
                    {
                        errorResult.Messages = e.ErrorMessages;
                    }
                    break;

                case KeyNotFoundException:
                    errorResult.Messages.Add(exception.Message);
                    errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case DbUpdateException:
                case SqlException:
                    errorResult.CategoryException = CategoryException.DataBase;
                    errorResult.StatusCode = (int)HttpStatusCode.BadRequest;
                    if (exception.GetBaseException() is SqlException sqlEx)
                    {
                        var message = GetCusEnumMessageBd(sqlEx);
                        errorResult.Exception = message;
                        errorResult.Messages.Add(message);
                    }
                    break;
                case AuthenticationException:
                    errorResult.CategoryException = CategoryException.Security;
                    errorResult.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;
                default:
                    errorResult.Messages.Add(exception.Message);
                    errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            errorResult.TechnicalMessage = string.Format(ResourceTexts.RequestFailed, errorResult.StatusCode, errorResult.Exception);
            return errorResult;
        }

        #region Codigo Errores SQL

        internal readonly struct CodeSql
        {
            /// <summary>
            /// SQL Error Code InsertarValoresNulos
            /// Cannot insert NULL value into column '%1!', table '%2!'. The column is not nullable. Error %3!.
            /// </summary>
            public const int CodeInsertValuessNulll = 515;

            /// <summary>
            /// SQL Error Code IdentityInsert
            /// Cannot insert explicit value into identity column of table '%1!' when IDENTITY_INSERT is OFF.
            /// </summary>
            public const int CodeIdentityInsert = 544;

            /// <summary>
            /// SQL Error Code ConflictoRestriccion
            /// Instruction %1! conflicting with constraint %2! "%3!". Conflict occurred in database "%4!", table "%5!"%6!%7!%8!.
            /// </summary>
            public const int CodeConflictRestriccion = 547;
            /// <summary>
            /// SQL Error Code ClaveDuplicada
            /// Cannot insert duplicate key row into object '%1!' with unique index '%2!'. The duplicate key value is %3!.
            /// </summary>
            public const int CodeUniquekey = 2601;
            /// <summary>
            /// SQL Error Code RestriccionClaveDuplicada
            /// Violation of constraint %1! '%2!'. Cannot insert duplicate key into object '%3!'. The duplicate key value is %4!.
            /// </summary>
            public const int CodeDuplicateKeyRestriction = 2627;
            /// <summary>
            /// SQL Error Code ViolationOfMaxLengthstaticraint
            /// String or binary data would be truncated.
            /// </summary>
            public const int CodeDataTruncated = 8152;
            /// <summary>
            /// SQL Error Code ViolationOfMaxValuestaticraint
            /// </summary>
            public const int CodeViolationOfMaxValueConstraint = 8115;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlEx"></param>
        /// <returns></returns>
        internal static string GetCusEnumMessageBd(SqlException sqlEx)
        {
            if (sqlEx.Number == CodeSql.CodeUniquekey || sqlEx.Number == CodeSql.CodeDuplicateKeyRestriction)
            {
                return ResourceValidations.CodeUniqueKey;
            }
            if (sqlEx.Number == CodeSql.CodeInsertValuessNulll)
            {
                return ResourceValidations.CodeInsertValuessNull;
            }
            if (sqlEx.Number == CodeSql.CodeConflictRestriccion)
            {
                return ResourceValidations.CodeConflictRestriccion;
            }
            if (sqlEx.Number == CodeSql.CodeDataTruncated)
            {
                return ResourceValidations.CodeDataTruncated;
            }
            if (sqlEx.Number == CodeSql.CodeViolationOfMaxValueConstraint)
            {
                return ResourceValidations.CodeViolationOfMaxValueConstraint;
            }

            return ResourceValidations.GeneralSqlException;
        }

        #endregion
    }
}