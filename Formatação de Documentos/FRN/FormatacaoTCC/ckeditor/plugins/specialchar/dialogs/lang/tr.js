xis.
     * @param offset New offset in the Y axis.
     */
    withDefaultOffsetY(offset: number): this;
    /**
     * Configures that the position strategy should set a `transform-origin` on some elements
     * inside the overlay, depending on the current position that is being applied. This is
     * useful for the cases where the origin of an animation can change depending on the
     * alignment of the overlay.
     * @param selector CSS selector that will be used to find the target
     *    elements onto which to set the transform origin.
     */
    withTransformOriginOn(selector: string): this;
    /**
     * Gets the (x, y) coordinate of a connection point on the origin based on a relative position.
     */
    private _getOriginPoint;
    /**
     * Gets the (x, y) coordinate of the top-left corner of the overlay given a given position and
     * origin point to which the overlay should be connected.
     */
    private _getOverlayPoint;
    /** Gets how well an overlay at the given point will fit within the viewport. */
    private _getOverlayFit;
    /**
     * Whether the overlay can fit within the viewport when it may resize either its width or height.
     * @param fit How well the overlay fits in the viewport at some position.
     * @param point The (x, y) coordinates of the overlat at some position.
     * @param viewport The geometry of the viewport.
     */
    private _canFitWithFlexibleDimensions;
    /**
     * Gets the point at which the overlay can be "pushed" on-screen. If the overlay is larger than
     * the viewport, the top-left corner will be pushed on-screen (with overflow occuring on the
     * right and bottom).
     *
     * @param start Starting point from which the overlay is pushed.
     * @param overlay Dimensions of the overlay.
     * @param scrollPosition Current viewport scroll position.
     * @returns The point at which to position the overlay after pushing. This is effectively a new
     *     originPoint.
     */
    private _pushOverlayOnScreen;
    /**
     * Applies a computed position to the overlay and emits a position change.
     * @param position The position preference
     * @param originPoint The point on the origin element where the overlay is connected.
     */
    private _applyPosition;
    /** Sets the transform origin based on the configured selector and the passed-in position.  */
    private _setTransformOrigin;
    /**
     * Gets the position and size of the overlay's sizing container.
     *
     * This method does no measuring and applies no styles so that we can cheaply compute the
     * bounds for all positions and choose the best fit based on these results.
     */
    private _calculateBoundingBoxRect;
    /**
     * Sets the position and size of the overlay's sizing wrapper. The wrapper is positioned on the
     * origin's connection point and stetches to the bounds of the viewport.
     *
     * @param origin The point on the origin element where the overlay is connected.
     * @param position The position preference
     */
    private _setBoundingBoxStyles;
    /** Resets the styles for the bounding box so that a new positioning can be computed. */
    private _resetBoundingBoxStyles;
    /** Resets the styles for the overlay pane so that a new positioning can be computed. */
    private _resetOverlayElementStyles;
    /** Sets positioning styles to the overlay element. */
    private _setOverlayElementStyles;
    /** Gets the exact top/bottom for the overlay when not using flexible sizing or when pushing. */
    private _getExactOverlayY;
    /** Gets the exact left/right for the overlay when not using flexible sizing or when pushing. */
    private _getExactOverlayX;
    /**
     * Gets the view properties of the trigger and overlay, including whether they are clipped
     * or completely outside the view of any of the strategy's scrollables.
     */
    private _getScrollVisibility;
    /** Subtracts the amount that an element is overflowing on an axis from it's length. */
    private _subtractOverflows;
    /** Narrows the given viewport rect by the current _viewportMargin. */
    private _getNarrowedViewportRect;
    /** Whether the we're dealing with an RTL context */
    private _isRtl;
    /** Determines whether the overlay uses exact or flexible positioning. */
    private _hasExactPosition;
    /** Retrieves the offset of a position along the x or y axis. */
    private _getOffset;
    /** Validates t