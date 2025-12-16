using ServiceStack.OrmLite;

namespace BaoCao1.Services
{
    public class BaseService
    {
        protected OrmLiteConnectionFactory _ormLiteConnectionFactory;
        protected string _connectionString;

        public BaseService()
        {
            var appSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = appSetting["ConnectionStrings:DefaultConnection"]!;
            }

            OrmLiteConfig.DialectProvider = SqlServerDialect.Provider;
            _ormLiteConnectionFactory = new OrmLiteConnectionFactory(_connectionString, OrmLiteConfig.DialectProvider);
            OrmLiteConfig.DialectProvider.GetStringConverter().UseUnicode = true;
        }

    }
}
