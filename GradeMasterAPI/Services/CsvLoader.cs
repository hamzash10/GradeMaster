namespace GradeMasterAPI.Services
{
    public class CsvLoader : ICsvLoader
    {

        string testval;

        public CsvLoader()
        {
            testval=Guid.NewGuid().ToString();
        }

        public string Test()
        {
            return testval;
        }
    }
}
