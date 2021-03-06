﻿namespace MusixMatch_API.APIMethods.Track
{
    public class TrackSearch : BaseApiParams, IQueryable
    {
        public int? FilterOnArtistId;
        public int? FilterOnArtistMusicBrainzId;
        public int? FilterOnMusicCategoryId;
        public int? FilterOnMusicGenreId;
        public bool? HasLyrics;
        public string Language;

        public sbyte? Page;

        // from 1 to 100
        public sbyte? PageSize;

        public string Query;
        public string QueryArtist;
        public string QueryLyrics;

        public string QueryTrack;

        // Search only a part of the given query string. Range is 0.1 - 1.0, with 1 being 100%
        public float? QuorumFactor = 1f;

        public Sort? SortOnArtistRating;

        // 0 = asc, 1 = desc.
        public Sort? SortOnTrackRating;

        public string Url { get; } = "track.search?";

        public string ToUrlParams()
        {
            Filter = new FilterCollection();

            AddFilter("q", Query);
            AddFilter("q_lyrics", QueryLyrics);
            AddFilter("q_track", QueryTrack);
            AddFilter("q_artist", QueryArtist);
            AddFilter("page", Page);
            AddFilter("page_size", PageSize);
            AddFilter("f_has_lyrics", HasLyrics);
            AddFilter("f_artist_id", FilterOnArtistId);
            AddFilter("f_music_genre_id", FilterOnMusicGenreId);
            AddFilter("f_artist_mbid", FilterOnArtistMusicBrainzId);
            AddFilter("f_lyrics_language", Language);
            AddFilter("s_track_rating", SortOnTrackRating);
            AddFilter("s_artist_rating", SortOnArtistRating);
            AddFilter("quorum_factor", QuorumFactor);

            return Url + Filter;
        }
    }
}