//
//  Minion.h
//  Fluffy Pug
//
//  Created by Matthew French on 9/10/15.
//  Copyright © 2015 Matthew French. All rights reserved.
//

#include "Position.h"

typedef struct Minion {
    Position topLeft, topRight, bottomLeft, bottomRight, characterCenter;
    bool detectedTopLeft=false, detectedBottomLeft=false, detectedTopRight=false, detectedBottomRight=false;
    double health=0;
} Minion;