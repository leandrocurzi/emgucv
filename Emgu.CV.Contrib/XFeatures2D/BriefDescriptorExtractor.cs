//----------------------------------------------------------------------------
//  Copyright (C) 2004-2018 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.Features2D;

namespace Emgu.CV.XFeatures2D
{
    /// <summary>
    /// BRIEF Descriptor
    /// </summary>
    public class BriefDescriptorExtractor : Feature2D
    {
        private IntPtr _sharedPtr;

        /// <summary>
        /// Create a BRIEF descriptor extractor.
        /// </summary>
        /// <param name="descriptorSize">The size of descriptor. It can be equal 16, 32 or 64 bytes.</param>
        public BriefDescriptorExtractor(int descriptorSize = 32)
        {
            _ptr = XFeatures2DInvoke.cveBriefDescriptorExtractorCreate(descriptorSize, ref _feature2D, ref _sharedPtr);
        }

        /// <summary>
        /// Release all the unmanaged resource associated with BRIEF
        /// </summary>
        protected override void DisposeObject()
        {
            if (_ptr != IntPtr.Zero)
                XFeatures2DInvoke.cveBriefDescriptorExtractorRelease(ref _ptr, ref _sharedPtr);
            base.DisposeObject();
        }
    }

    public static partial class XFeatures2DInvoke
    {
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal extern static IntPtr cveBriefDescriptorExtractorCreate(int descriptorSize, ref IntPtr feature2D, ref IntPtr sharedPtr);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal extern static void cveBriefDescriptorExtractorRelease(ref IntPtr extractor, ref IntPtr sharedPtr);
    }
}
