﻿using System;
namespace MusixMatchApiService.Models
{
    public class MusicData
    {
        public Message message { get; set; }

        public class Header
        {
            public int status_code { get; set; }
            public double execute_time { get; set; }
        }
        public class Lyrics
        {
            public int lyrics_id { get; set; }
            public int explicit_ { get; set; }
            public string lyrics_body { get; set; }
            public string script_tracking_url { get; set; }
            public string pixel_tracking_url { get; set; }
            public string lyrics_copyright { get; set; }
            public DateTime updated_time { get; set; }
        }
        public class Body
        {
            public Lyrics lyrics { get; set; }
        }
        public class Message
        {
            public Header header { get; set; }
            public Body body { get; set; }
        }
    }
}
