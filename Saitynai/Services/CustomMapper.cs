using Saitynai.DTO.Response;
using Saitynai.Models;

namespace Saitynai.Services
{

    public interface ICustomMapper
    {
        CategoryRespDto Mapper(Category category);
        PlaylistRespDto Mapper(Playlist playlist);
        SongRespDto Mapper(Song song);
        UserRespDto Mapper(User user);
    }

    public class CustomMapper : ICustomMapper
    {
        public CategoryRespDto Mapper(Category category)
        {
            return new CategoryRespDto()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };
        }

        public PlaylistRespDto Mapper(Playlist playlist)
        {
            var songs = new List<SongRespDto>();

            foreach (var song in playlist.Songs)
            {
                // songs.Append(Mapper(song));
            }

            return new PlaylistRespDto()
            {
                CategoryId = playlist.Categorie.CategoryId,
                // Songs = songs, 
                Created = playlist.Created,
                PlaylistId = playlist.PlaylistId,
                Title = playlist.Title,
                Url = playlist.Url
            };
        }

        public SongRespDto Mapper(Song song)
        {
            return new SongRespDto()
            {
                SongId = song.SongId,
                PlaylistId = song.Playlist.PlaylistId,
                Downloaded = song.Downloaded,
                DownloadedDate = song.DownloadedDate,
                Url = song.Url
            };
        }

        public UserRespDto Mapper(User user)
        {
            return new UserRespDto { UserId = user.UserId, Username = user.Username, Role= user.Role };
        }
    }
}
