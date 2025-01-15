using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcSchool.Models
{
    public class LessonGenreViewModel
    {
        public List<Lesson>? Lessons { get; set; }
        public SelectList? Genres { get; set; }
        public string? LessonGenre { get; set; }
        public string? SearchString { get; set; }
        public List<Lesson>? lessons { get; internal set; }
    }
}

