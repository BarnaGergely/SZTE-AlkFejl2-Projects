using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System.Globalization;

namespace ConsoleAppProject
{
    public class IntConverter<T> : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "NA")
            {
                return 0;
            }
            else
            {
                return int.Parse(text);
            }
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.ToString();
        }
    }

    public class FloatConverter<T> : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "NA")
            {
                return float.Parse("0", CultureInfo.InvariantCulture.NumberFormat);
            }
            else
            {
                return float.Parse(text, CultureInfo.InvariantCulture.NumberFormat);
            }
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return value.ToString();
        }
    }

    public class TeamRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Team { get; set; }
        public string NOC { get; set; }

        public virtual string? ToString()
        {
            return ID + " " + Name + " " + Sex + " " + Age + " " + Height + " " + Weight + " " + Team + " " + NOC;
        }
    }

    public class TeamMap : ClassMap<TeamRecord>
    {
        public TeamMap()
        {
            Map(m => m.ID).TypeConverter<IntConverter<int>>().Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Sex).Name("Sex");
            Map(m => m.Age).TypeConverter<IntConverter<int>>().Name("Age");
            Map(m => m.Height).TypeConverter<FloatConverter<float>>().Name("Height");
            Map(m => m.Weight).TypeConverter<FloatConverter<float>>().Name("Weight");
            Map(m => m.Team).Name("Team");
            Map(m => m.NOC).Name("NOC");

        }
    }
}