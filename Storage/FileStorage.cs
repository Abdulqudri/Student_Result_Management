using System.Text.Json;

namespace StudentResults.Storage
{
    class FileStorage
    {
        private const string filePath = "students.json";
        
        public static void Save(List<Student> students)
        {
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public static List<Student> Load()
        {
            if (!File.Exists(filePath))
            {
                return new List<Student>();
            }

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            
        }
    }
}