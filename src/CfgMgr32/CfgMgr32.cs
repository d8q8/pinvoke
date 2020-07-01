﻿// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the CfgMgr32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class CfgMgr32
    {
        /// <summary>
        /// The callback routine invoked by the Configuration Manager when listening for events.
        /// </summary>
        /// <param name="notify">
        /// The handle of the notification context which invoked the callback.
        /// </param>
        /// <param name="context">
        /// A user-provided callback context.
        /// </param>
        /// <param name="action">
        /// The device action which triggered the callback.
        /// </param>
        /// <param name="eventData">
        /// The callback data.
        /// </param>
        /// <param name="eventDataSize">
        /// The size of the callback data struct.
        /// </param>
        /// <returns>
        /// If responding to a <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEQUERYREMOVE"/> notification,
        /// the <see cref="CM_NOTIFY_CALLBACK"/> callback should return either <see cref="Win32ErrorCode.ERROR_SUCCESS"/> or <see cref="Win32ErrorCode.ERROR_CANCELLED"/>,
        /// as appropriate. Otherwise, the callback should return <see cref="Win32ErrorCode.ERROR_SUCCESS"/>.
        /// The callback should not return any other values.
        /// </returns>
        public unsafe delegate Win32ErrorCode CM_NOTIFY_CALLBACK(
            SafeNotificationHandle notify,
            void* context,
            CM_NOTIFY_ACTION action,
            IntPtr eventData,
            uint eventDataSize);

        /// <summary>
        /// The <see cref="CM_Register_Notification(IntPtr, void*, IntPtr, out SafeNotificationHandle)"/> function registers an application callback routine to be called when a PnP event of the specified type occurs.
        /// </summary>
        /// <param name="pFilter">
        /// Pointer to a <see cref="CM_NOTIFY_FILTER"/> structure.
        /// </param>
        /// <param name="pContext">
        /// Pointer to a caller-allocated buffer containing the context to be passed to the callback routine in <see cref="AsyncCallback"/>.
        /// </param>
        /// <param name="pCallback">
        /// Pointer to the routine to be called when the specified PnP event occurs.
        /// </param>
        /// <param name="pNotifyContext">
        /// Pointer to receive the <c>HCMNOTIFICATION</c> handle that corresponds to the registration call.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="CONFIGRET.CR_SUCCESS"/>.
        /// Otherwise, it returns one of the error codes defined in <see cref="CONFIGRET"/>.
        /// </returns>
        [DllImport(nameof(CfgMgr32), ExactSpelling = true)]
        public static unsafe extern CONFIGRET CM_Register_Notification(
            IntPtr pFilter,
            void* pContext,
            IntPtr pCallback,
            out SafeNotificationHandle pNotifyContext);

        /// <summary>
        /// The <see cref="CM_Unregister_Notification"/> function closes the specified <c>HCMNOTIFICATION</c> handle.
        /// </summary>
        /// <param name="pNotifyContext">
        /// The <c>HCMNOTIFICATION</c> handle returned by the <see cref="CM_Register_Notification(IntPtr, void*, IntPtr, out SafeNotificationHandle)"/> function.
        /// </param>
        /// <returns>
        /// If the operation succeeds, the function returns <see cref="CONFIGRET.CR_SUCCESS"/>.
        /// Otherwise, it returns one of the error codes defined in <see cref="CONFIGRET"/>.
        /// </returns>
        [DllImport(nameof(CfgMgr32), ExactSpelling = true)]
        private static extern CONFIGRET CM_Unregister_Notification(
            IntPtr pNotifyContext);
    }
}
