﻿using System.Buffers;
using TiffLibrary.PixelConverter;

namespace TiffLibrary
{
    /// <summary>
    /// A series of options to control the behavior of <see cref="TiffImageDecoder"/>.
    /// </summary>
    public class TiffImageDecoderOptions
    {
        internal static TiffImageDecoderOptions Default { get; } = new TiffImageDecoderOptions();

        /// <summary>
        /// The memory pool to use when allocating large chunk of memory.
        /// </summary>
        public MemoryPool<byte>? MemoryPool { get; set; }

        /// <summary>
        /// An <see cref="ITiffPixelConverterFactory"/> instance used to create pixel converters to convert pixels in one color space to another.
        /// </summary>
        public ITiffPixelConverterFactory? PixelConverterFactory { get; set; } = TiffDefaultPixelConverterFactory.Instance;

        /// <summary>
        /// When this flag is set, the decoder will utilize the associated alpha channel in RGB image if possible and undo color pre-multiplying to restore alpha chanel in the output RGBA image. Otherwise the associated alpha channel is ignored.
        /// </summary>
        public bool UndoColorPreMultiplying { get; set; }

        /// <summary>
        /// When this flag is set, the Orientation tag in the IFD is ignored. Image will not be flipped or oriented according to the tag.
        /// </summary>
        public bool IgnoreOrientation { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of concurrent decoding pipelines enabled by this <see cref="TiffImageDecoderOptions"/> instance.
        /// </summary>
        public int MaxDegreeOfParallelism { get; set; } = 1;
    }
}
