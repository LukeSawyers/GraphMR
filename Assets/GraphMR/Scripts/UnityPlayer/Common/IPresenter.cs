using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiagramMR
{
    /// <summary>
    /// Represents a class that presents a window for UI that is to be managed by the active window system
    /// </summary>
    public interface IPresenter
    {
        /// <summary>
        /// The name of this window
        /// </summary>
        string WindowName { get; }

        /// <summary>
        /// The options for this window
        /// </summary>
        WindowOption WindowOptions { get; }

        /// <summary>
        /// The minimum or static size of this window
        /// </summary>
        Vector2 WindowSize { get; }

        /// <summary>
        /// The location of this window if it is to be drawn statically
        /// </summary>
        Vector2 WindowLocation { get; }

        /// <summary>
        /// Draw this window
        /// </summary>
        void Draw();
        
    }

    /// <summary>
    /// Options for a window
    /// </summary>
    public enum WindowOption
    {
        /// <summary>
        /// Indicates that none of the options are enabled
        /// </summary>
        None = 0,

        /// <summary>
        /// The window can be moved. If false the window presenter should ask for the draw location
        /// </summary>
        Movable = 1,
        
        /// <summary>
        /// The window is resizeable. If true the window size will be used as the minimum size, if false the window size will be set
        /// </summary>
        Resizable = 2

    }
}