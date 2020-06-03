﻿**************************************
*          HIGHLIGHT PLUS            *
* Created by Ramiro Oliva (Kronnect) * 
*            README FILE             *
**************************************


Notice about Universal Rendering Pipeline
-----------------------------------------
This package is designed for URP.
It requires Unity 2019.3 and URP 7.1.6 or later
To install the plugin correctly:

1) Make sure you have Universal Rendering Pipeline asset installed (from Package Manager).
2) Go to Project Settings / Graphics.
3) Double click the Universal Rendering Pipeline asset.
4) Double click the Forward Renderer asset.
5) Click "+" to add the Highlight Plus Renderer Feature to the list of the Forward Renderer Features.

You can also find a HighlightPlusForwardRenderer asset in the Highlight Plus / Pipelines / URP folder.
Make sure the Highlight Plus Scriptable Renderer Feature is listed in the Renderer Features of the  Forward Renderer in the pipeline asset.


Quick help: how to use this asset?
----------------------------------

1) Highlighting specific objects: add HighlightEffect.cs script to any GameObject. Customize the appearance options.
  In the Highlight Effect inspector, you can specify which objects, in addition to this one, are also affected by the effect:
    a) Only this object
    b) This object and its children
    c) All objects from the root to the children
    d) All objects belonging to a layer

2) Control highlight effect when mouse is over:
  Add HighlightTrigger.cs script to the GameObject. It will activate highlight on the gameobject when mouse pass over it.

3) Highlighting any object in the scene:
  Select top menu GameObject -> Effects -> Highlight Plus -> Create Manager.
  Customize appearance and behaviour of Highlight Manager. Those settings are default settings for all objects. If you want different settings for certain objects just add another HighlightEffect script to each different object. The manager will use those settings.

4) Make transparent shaders compatible with See-Through effect:
  If you want the See-Through effect be seen through other transparent objects, they need to be modified so they write to depth buffer (by default transparent objects do not write to z-buffer).
  To do so, select top menu GameObject -> Effects -> Highlight Plus -> Add Depth To Transparent Object.

5) Static batching:
  Objects marked as "static" need a MeshCollider in order to be highlighted. This is because Unity combines the meshes of static objects so it's not possible to highlight individual objects if their meshes are combined.
  To allow highlighting static objects make sure they have a MeshCollider attached (the MeshCollider can be disabled).



Online help & Forum
-------------------

Online manual: https://kronnect.freshdesk.com/support/solutions/42000065090

Have any question or issue?
* Email: contact@kronnect.me
* Support Forum: http://kronnect.me
* Twitter: @KronnectGames

If you like Highlight Plus, please rate it on the Asset Store. It encourages us to keep improving it! Thanks!



Future updates
--------------

All our assets follow an incremental development process by which a few beta releases are published on our support forum (kronnect.com).
We encourage you to signup and engage our forum. The forum is the primary support and feature discussions medium.

Of course, all updates of Highlight Plus will be eventually available on the Asset Store.



More Cool Assets!
-----------------
Check out our other assets here:
https://assetstore.unity.com/publishers/15018



Version history
---------------

Version 4.2
- Glow/Outline downsampling option added to profiles
- [Fix] Removed VR API usage console warning

Version 4.1
- Added Outline Independent option
- [Fix] Fixed error when highlight script is added to an empty gameobject

Version 4.0
- Support for URP Scriptable Rendering Feature
