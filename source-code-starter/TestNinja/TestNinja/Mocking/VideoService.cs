using System.Collections.Generic;
using System.Data.Entity;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IVideoRepository _videoRepository;

        // Dependency injection via constructor
        // With null we make the parameter fileReader optional
        // This is okay for a small project, but if we use a framework we dont need it
        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            // If fileReader is not null, we use the parameter
            // If fileReader is null we create a new one
            _fileReader = fileReader ?? new FileReader();
            _videoRepository = repository ?? new VideoRepository();
        }
        // Dependency injection via Parameters works okay,
        // but you have to change all the places where you call this method
        // public string ReadVideoTitle(IFileReader fileReader)

        // Dependency injection via Properties is nice,
        // but some dependency injection frameworks can not use it
        // public IFileReader FileReader { get; set; }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            return video == null ? "Error parsing the video." : video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            // We need to extract this -> VideoRepository
            // using (var context = new VideoContext())

            // We need to extract this -> VideoRepository
            // var videos =
            //     (from video in context.Videos
            //         where !video.IsProcessed
            //         select video).ToList();

            // We need to use an interface
            // var videos = new VideoRepository().GetUnprocessedVideos()
            var videos = _videoRepository.GetUnprocessedVideos();
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return string.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}