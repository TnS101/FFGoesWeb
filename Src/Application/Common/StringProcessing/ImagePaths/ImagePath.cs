namespace Application.Common.StringProcessing.ImagePaths
{
    public class ImagePath
    {
        public ImagePath()
        {
        }

        public string Process(string[] values)
        {
            string section = values[0];
            string subSection;
            string name;

            if (values.Length == 2)
            {
                subSection = string.Empty;
                name = values[1];
            }
            else
            {
                subSection = $"/{values[1]}";
                name = values[2];
            }

            if (section.EndsWith('s'))
            {
                section += "es";
            }
            else
            {
                section += "s";
            }

            if (subSection != string.Empty)
            {
                if (subSection.EndsWith('s'))
                {
                    subSection += "es";
                }
                else
                {
                    subSection += "s";
                }
            }

            return $"/images/{section}{subSection}/{name}.png";
        }

        public string IconProcess(string name)
        {
            return $"/images/Icons/{name}-Icon.png";
        }
    }
}
