namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            if (line == null)
            {
                logger.LogWarning("return null");
                return null;
            }

            var cells= line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogWarning("return null");
                return null;
            }

            double latitude;
            double longitude;

           if(!double.TryParse(cells[0], out latitude) || !double.TryParse(cells[1], out longitude))
            {
                logger.LogWarning("return null");
                return null;
            }

            string locationName = cells[2].Trim();

            //catch invalid input

            if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180 || locationName.Length < 1 || locationName.ToLower()[0] != 't' || !locationName.ToLower().Contains("Taco Bell"))
                return null;

            //instantiate TacoBell and Point
            TacoBell tacobell = new TacoBell();

            Point point = new Point(latitude, longitude);

            //Set Name and Location


            // Do not fail if one record parsing fails, return null
            return null; // TODO Implement
        }
            
    }
}