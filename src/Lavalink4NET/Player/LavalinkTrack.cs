/*
 *  File:   LavalinkTrack.cs
 *  Author: Angelo Breuer
 *
 *  The MIT License (MIT)
 *
 *  Copyright (c) Angelo Breuer 2019
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */

namespace Lavalink4NET.Player
{
    using System;
    using Lavalink4NET.Util;
    using Newtonsoft.Json;

    /// <summary>
    ///     The information of a lavalink track.
    /// </summary>
    public class LavalinkTrack
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LavalinkTrack"/> class.
        /// </summary>
        /// <param name="identifier">the track identifier</param>
        /// <param name="info">the track info</param>
        /// <exception cref="ArgumentNullException">
        ///     thrown if the specified <paramref name="identifier"/> is blank.
        /// </exception>
        public LavalinkTrack(string identifier, LavalinkTrackInfo info)
            : this(info)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentException("The specified identifier can not be blank.", nameof(identifier));
            }

            Identifier = identifier;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LavalinkTrack"/> class.
        /// </summary>
        /// <param name="info">the track info</param>
        /// <exception cref="ArgumentNullException">
        ///     the specified <paramref name="info"/> can not be <see langword="null"/>.
        /// </exception>
        [JsonConstructor]
        internal LavalinkTrack(LavalinkTrackInfo info)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            Author = info.Author;
            Title = info.Title;
            Source = info.Source;
            Duration = info.Duration;
            IsLiveStream = info.IsLiveStream;
            IsSeekable = info.IsSeekable;
            TrackIdentifier = info.TrackIdentifier;
            Provider = StreamProviderUtil.GetStreamProvider(info.Source);
        }

        /// <summary>
        ///     Gets the name of the track author.
        /// </summary>
        [JsonIgnore]
        public string Author { get; }

        /// <summary>
        ///     Gets the duration of the track.
        /// </summary>
        [JsonIgnore]
        public TimeSpan Duration { get; }

        /// <summary>
        ///     Gets a unique track identifier.
        /// </summary>
        [JsonRequired, JsonProperty("track")]
        public string Identifier { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether the track is a live stream.
        /// </summary>
        [JsonIgnore]
        public bool IsLiveStream { get; }

        /// <summary>
        ///     Gets a value indicating whether the track is seek-able.
        /// </summary>
        [JsonIgnore]
        public bool IsSeekable { get; }

        /// <summary>
        ///     Gets the track source.
        /// </summary>
        [JsonIgnore]
        public string Source { get; }

        /// <summary>
        ///     Gets the title of the track.
        /// </summary>
        [JsonIgnore]
        public string Title { get; }

        /// <summary>
        ///     Gets the unique track identifier (Example: dQw4w9WgXcQ, YouTube Video ID).
        /// </summary>
        [JsonIgnore]
        public string TrackIdentifier { get; }

        /// <summary>
        ///     Gets the stream provider (e.g. YouTube).
        /// </summary>
        [JsonIgnore]
        public StreamProvider Provider { get; }
    }
}