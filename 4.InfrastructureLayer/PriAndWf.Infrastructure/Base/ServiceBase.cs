using System.Globalization;

namespace PriAndWf.Infrastructure.Base
{
    public class ServiceBase
    {
        //public ILogger Logger { protected get; set; }
        //public IObjectMapper ObjectMapper { get; set; }
        //public ILocalizationManager LocalizationManager { get; set; }

        //protected ServiceBase()
        //{
        //    Logger = NullLogger.Instance;
        //    ObjectMapper = NullObjectMapper.Instance;
        //    LocalizationManager = NullLocalizationManager.Instance;
        //}

        ///// <summary>
        ///// Reference to the setting manager.
        ///// </summary>
        //public ISettingManager SettingManager { get; set; }

        ///// <summary>
        ///// Reference to <see cref="IUnitOfWorkManager"/>.
        ///// </summary>
        //public IUnitOfWorkManager UnitOfWorkManager
        //{
        //    get
        //    {
        //        if (_unitOfWorkManager == null)
        //        {
        //            throw new AbpException("Must set UnitOfWorkManager before use it.");
        //        }

        //        return _unitOfWorkManager;
        //    }
        //    set { _unitOfWorkManager = value; }
        //}
        //private IUnitOfWorkManager _unitOfWorkManager;

        ///// <summary>
        ///// Gets current unit of work.
        ///// </summary>
        //protected IActiveUnitOfWork CurrentUnitOfWork { get { return UnitOfWorkManager.Current; } }

        ///// <summary>
        ///// Reference to the localization manager.
        ///// </summary>
        

        ///// <summary>
        ///// Gets/sets name of the localization source that is used in this application service.
        ///// It must be set in order to use <see cref="L(string)"/> and <see cref="L(string,CultureInfo)"/> methods.
        ///// </summary>
        //protected string LocalizationSourceName { get; set; }

        ///// <summary>
        ///// Gets localization source.
        ///// It's valid if <see cref="LocalizationSourceName"/> is set.
        ///// </summary>
        //protected ILocalizationSource LocalizationSource
        //{
        //    get
        //    {
        //        if (LocalizationSourceName == null)
        //        {
        //            throw new ExceptionBase("Must set LocalizationSourceName before, in order to get LocalizationSource");
        //        }

        //        if (_localizationSource == null || _localizationSource.Name != LocalizationSourceName)
        //        {
        //            _localizationSource = LocalizationManager.GetSource(LocalizationSourceName);
        //        }

        //        return _localizationSource;
        //    }
        //}
        //private ILocalizationSource _localizationSource;
    }
}
