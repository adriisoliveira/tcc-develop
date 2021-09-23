tItem.width : 0
        }

        Connections {
            target: flickableItem

            onContentYChanged:  {
                scroller.blockUpdates = true
                scroller.verticalScrollBar.value = flickableItem.contentY - flickableItem.originY
                scroller.blockUpdates = false
            }

            onContentXChanged:  {
                scroller.blockUpdates = true
                scroller.horizontalScrollBar.value = flickableItem.contentX - flickableItem.originX
                scroller.blockUpdates = false
            }

        }

        anchors.fill: parent

        Component {
            id: flickableComponent
            Flickable {}
        }

        WheelArea {
            id: wheelArea
            parent: flickableItem
            z: -1
            // ### Note this is needed due to broken mousewheel behavior in Flickable.

            anchors.fill: parent

            property int acceleration: 40
            property int flickThreshold: Settings.dragThreshold
            property real speedThreshold: 3
            property real ignored: 0.001 // ## flick() does not work with 0 yVelocity
            property int maxFlick: 400

            property bool horizontalRecursionGuard: false
            property bool verticalRecursionGuard: false

            horizontalMinimumValue: 0
            horizontalMaximumValue: flickableItem ? flickableItem.contentWidth - viewport.width : 0
            onHorizontalMaximumValueChanged: {
                wheelArea.horizontalRecursionGuard = true
                //if horizontalMaximumValue changed, horizontalValue may be actually synced with
                wheelArea.horizontalValue = flickableItem.contentX - flickableItem.originX;
                wheelArea.horizontalRecursionGuard = false
            }

            verticalMinimumValue: 0
            verticalMaximumValue: flickableItem ? flickableItem.contentHeight - viewport.height + __viewTopMargin : 0
            onVerticalMaximumValueChanged: {
                wheelArea.verticalRecursionGuard = true
                //if verticalMaximumValue changed, verticalValue may be actually synced with
                wheelArea.verticalValue = flickableItem.contentY - flickableItem.originY;
                wheelArea.verticalRecursionGuard = false
            }

            // The default scroll speed for typical angle-based mouse wheels. The value
            // comes originally from QTextEdit, which sets 20px steps by default, as well as
            // QQuickWheelArea.
            // TODO: centralize somewhere, QPlatformTheme?
            scrollSpeed: 20 * (__style && __style.__wheelScrollLines || 1)

            Connections {
                target: flickableItem

                onContentYChanged: {
                    wheelArea.verticalRecursionGuard = true
                    wheelArea.verticalValue = flickableItem.contentY - flickableItem.originY
                    wheelArea.verticalRecursionGuard = false
                }
                onContentXChanged: {
                    wheelArea.horizontalRecursionGuard = true
                    wheelArea.horizontalValue = flickableItem.contentX - flickableItem.originX
                    wheelArea.horizontalRecursionGuard = false
                }
            }

            onVerticalValueChanged: {
                if (!verticalRecursionGuard) {
                    var effectiveContentY = flickableItem.contentY - flickableItem.originY
                    if (effectiveContentY < flickThreshold && verticalDelta > speedThreshold) {
                        flickableItem.flick(ignored, Math.min(maxFlick, acceleration * verticalDelta))
                    } else if (effectiveContentY > flickableItem.contentHeight - flickThreshold - viewport.height
                               && verticalDelta < -speedThreshold) {
                        flickableItem.flick(ignored, Math.max(-maxFlick, acceleration * verticalDelta))
                    } else {
                        flickableItem.contentY = verticalValue + flickableItem.originY
                    }
                }
            }

            onHorizontalValueChanged: {
                if (!horizontalRecursionGuard)
                    flickableItem.contentX = horizontalValue + flickableItem.originX
            }