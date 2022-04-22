"use strict";(function(){const bind=Function.prototype.bind;const eventHandlers=new Set();Object.defineProperty(Function.prototype,"bind",{"value":function(){const result=bind.apply(this,arguments);Object.defineProperty(result,"__source__",{"value":(this.__source__||this)});return result;}});Object.defineProperties(Object.prototype,{"attachEventHandler":{"value":function(type,handler){eventHandlers.add({"element":this,"type":type,"handler":handler});this.addEventListener(type,handler);}},"detachEventHandler":{"value":function(type,handler){let removeHandler=function(value,index,source){let eventHandler=value.handler;if((value.element===this)&&(value.type===type)&&((eventHandler.__source__||eventHandler)===(handler.__source__||handler))){this.removeEventListener(type,eventHandler);eventHandlers.delete(value);return true;}eventHandler=null;};Array.from(eventHandlers).some(removeHandler.bind(this));}}});})();let jsCrop=(function(){return Object.freeze({"initialise":function(imageElement,options={}){let currentInstance=imageElement.jsCropInstance;if(!currentInstance){let cropper={"minLeft":0,"minTop":0,"maxLeft":0,"maxTop":0,"minWidth":20,"minHeight":20,"maxWidth":0,"maxHeight":0,"originalWidth":0,"originalHeight":0,"originalLeft":0,"originalTop":0,"originalMouseX":0,"originalMouseY":0,"pageX":0,"pageY":0,"deltaX":0,"deltaY":0,"newLeft":0,"newTop":0,"newWidth":0,"newHeight":0,"mouseDownElement":null,"imageToCrop":null,"imageOverlay":null,"gridHolder":null,"grid":null,"cropResult":null,"resizers":{"topLeft":null,"topMid":null,"topRight":null,"rightMid":null,"botRight":null,"botMid":null,"botLeft":null,"leftMid":null},"imageOverlayContext":null,"cropResultContext":null,"gridHolderStyle":null,"cropResultStyle":null,"imageLeft":0,"imageTop":0,"imageRight":0,"imageBottom":0,"gridHolderLeft":0,"gridHolderTop":0,"gridHolderWidth":0,"gridHolderHeight":0,"enableCropMode":function(flag){if(flag){this.imageOverlay.style.removeProperty("opacity");this.gridHolderStyle.visibility="visible";this.gridHolderStyle.opacity="1";this.updateCropBackground();this.drawCroppedImage();}else{this.gridHolderStyle.removeProperty("opacity");this.imageOverlay.style.opacity="0";}},"setOutputCanvas":function(canvasElement){this.cropResult=canvasElement;this.cropResultStyle=canvasElement.style;this.cropResultContext=canvasElement.getContext("2d");this.drawCroppedImage();},"drawCroppedImage":function(){this.gridHolderLeft=this.gridHolder.offsetLeft;this.gridHolderTop=this.gridHolder.offsetTop;this.gridHolderWidth=this.gridHolder.offsetWidth;this.gridHolderHeight=this.gridHolder.offsetHeight;this.cropResult.width=this.gridHolderWidth;this.cropResultStyle.marginLeft=`${this.gridHolderLeft}px`;this.cropResult.height=this.gridHolderHeight;this.cropResultStyle.marginTop=`${this.gridHolderTop}px`;this.cropResultStyle.marginBottom=`${(this.imageToCrop.offsetHeight-(this.gridHolderHeight+this.gridHolderTop))}px`;this.cropResultContext.clearRect(0,0,this.gridHolderWidth,this.gridHolderHeight);this.cropResultContext.drawImage(this.imageToCrop,this.gridHolderLeft,this.gridHolderTop,this.gridHolderWidth,this.gridHolderHeight,0,0,this.gridHolderWidth,this.gridHolderHeight);},"downloadCroppedImage":function(){let anchorElement=document.createElement("a");let anchorElementStyle=anchorElement.style;this.drawCroppedImage();anchorElement.href=this.cropResult.toDataURL("image/png").replace("image/png","image/octet-stream");anchorElement.download=`${this.imageToCrop.src.match(/^.*[\\\/](.+?)(\.[^.]*$|$)/)[1]}-cropped.png`;anchorElementStyle.display="none";anchorElementStyle.visibility="hidden";anchorElementStyle.opacity=0;document.body.appendChild(anchorElement);anchorElement.click();setTimeout(function(){document.body.removeChild(anchorElement);anchorElementStyle=null;anchorElement=null;});},"fixGrid":function(){this.gridHolderLeft=this.gridHolder.offsetLeft;this.gridHolderTop=this.gridHolder.offsetTop;this.gridHolderWidth=this.gridHolder.offsetWidth;this.gridHolderHeight=this.gridHolder.offsetHeight;this.maxWidth=(this.imageToCrop.offsetWidth-this.gridHolderLeft);this.maxHeight=(this.imageToCrop.offsetHeight-this.gridHolderTop);if(this.mouseDownElement!==this.grid){if(this.gridHolderWidth>this.maxWidth)this.gridHolderStyle.width=`${this.maxWidth}px`;if(this.gridHolderHeight>this.maxHeight)this.gridHolderStyle.height=`${this.maxHeight}px`;if(this.gridHolderWidth<this.minWidth)this.gridHolderStyle.width=`${this.minWidth}px`;if(this.gridHolderHeight<this.minHeight)this.gridHolderStyle.height=`${this.minHeight}px`;}else{if(this.gridHolderWidth>this.maxWidth)this.gridHolderStyle.left=`${(this.gridHolder.offsetLeft-(this.gridHolderWidth-this.maxWidth))}px`;if(this.gridHolderHeight>this.maxHeight)this.gridHolderStyle.top=`${(this.gridHolder.offsetTop-(this.gridHolderHeight-this.maxHeight))}px`;}},"updateCropBackground":function(){this.imageOverlayContext.fillRect(0,0,this.imageOverlay.width,this.imageOverlay.height);this.imageOverlayContext.clearRect(this.gridHolder.offsetLeft,this.gridHolder.offsetTop,this.gridHolder.offsetWidth,this.gridHolder.offsetHeight);},"setCropRegion":function(left,top,width,height){if(left<this.minLeft)left=this.minLeft;if(top<this.minTop)top=this.minTop;this.gridHolderStyle.left=`${left}px`;this.gridHolderStyle.top=`${top}px`;this.gridHolderStyle.width=`${width}px`;this.gridHolderStyle.height=`${height}px`;this.fixGrid();this.updateCropBackground();this.drawCroppedImage();},"resizeGrid":function(event){event.preventDefault();this.pageX=event.pageX;this.pageY=event.pageY;this.deltaX=(this.pageX-this.originalMouseX);this.deltaY=(this.pageY-this.originalMouseY);this.newLeft=(this.originalLeft+this.deltaX);this.newTop=(this.originalTop+this.deltaY);if(this.newLeft<this.minLeft){this.newLeft=this.minLeft;if(this.mouseDownElement===this.resizers.botLeft||this.mouseDownElement===this.resizers.leftMid||this.mouseDownElement===this.resizers.topLeft)this.deltaX=(this.newLeft-this.originalLeft);}else if(this.newLeft>this.maxLeft)this.newLeft=this.maxLeft;if(this.newTop<this.minTop){this.newTop=this.minTop;if(this.mouseDownElement===this.resizers.topLeft||this.mouseDownElement===this.resizers.topMid||this.mouseDownElement===this.resizers.topRight)this.deltaY=(this.newTop-this.originalTop);}else if(this.newTop>this.maxTop)this.newTop=this.maxTop;this.newWidth=this.originalWidth;this.newHeight=this.originalHeight;switch(this.mouseDownElement){case this.resizers.topLeft:this.newWidth-=this.deltaX;this.newHeight-=this.deltaY;if(this.newWidth>this.minWidth){this.gridHolderStyle.left=`${this.newLeft}px`;this.gridHolderStyle.width=`${this.newWidth}px`;}if(this.newHeight>this.minHeight){this.gridHolderStyle.top=`${this.newTop}px`;this.gridHolderStyle.height=`${this.newHeight}px`;}break;case this.resizers.topMid:this.newHeight-=this.deltaY;if(this.newHeight>this.minHeight){this.gridHolderStyle.top=`${this.newTop}px`;this.gridHolderStyle.height=`${this.newHeight}px`;}break;case this.resizers.topRight:this.newWidth+=this.deltaX;this.newHeight-=this.deltaY;if(this.newWidth>this.minWidth)this.gridHolderStyle.width=`${this.newWidth}px`;if(this.newHeight>this.minHeight){this.gridHolderStyle.top=`${this.newTop}px`;this.gridHolderStyle.height=`${this.newHeight}px`;}break;case this.resizers.rightMid:this.newWidth+=this.deltaX;if(this.newWidth>this.minWidth)this.gridHolderStyle.width=`${this.newWidth}px`;break;case this.resizers.botRight:this.newWidth+=this.deltaX;this.newHeight+=this.deltaY;if(this.newWidth>this.minWidth)this.gridHolderStyle.width=`${this.newWidth}px`;if(this.newHeight>this.minHeight)this.gridHolderStyle.height=`${this.newHeight}px`;break;case this.resizers.botMid:this.newHeight+=this.deltaY;if(this.newHeight>this.minHeight)this.gridHolderStyle.height=`${this.newHeight}px`;break;case this.resizers.botLeft:this.newWidth-=this.deltaX;this.newHeight+=this.deltaY;if(this.newWidth>this.minWidth){this.gridHolderStyle.left=`${this.newLeft}px`;this.gridHolderStyle.width=`${this.newWidth}px`;}if(this.newHeight>this.minHeight)this.gridHolderStyle.height=`${this.newHeight}px`;break;case this.resizers.leftMid:this.newWidth-=this.deltaX;if(this.newWidth>this.minWidth){this.gridHolderStyle.left=`${this.newLeft}px`;this.gridHolderStyle.width=`${this.newWidth}px`;}break;case this.grid:if((this.newLeft<this.gridHolder.offsetLeft)||(this.gridHolder.offsetWidth<this.maxWidth))this.gridHolderStyle.left=`${this.newLeft}px`;if((this.newTop<this.gridHolder.offsetTop)||(this.gridHolder.offsetHeight<this.maxHeight))this.gridHolderStyle.top=`${this.newTop}px`;if((this.pageX>=this.imageLeft)&&(this.pageX<=this.imageRight)){if((this.gridHolder.offsetLeft===this.minLeft)||(this.gridHolder.offsetWidth===this.maxWidth)){this.originalMouseX+=this.deltaX;this.originalLeft=this.gridHolder.offsetLeft;}}if((this.pageY>=this.imageTop)&&(this.pageY<=this.imageBottom)){if((this.gridHolder.offsetTop===this.minTop)||(this.gridHolder.offsetHeight===this.maxHeight)){this.originalMouseY+=this.deltaY;this.originalTop=this.gridHolder.offsetTop;}}break;default:break;}this.fixGrid();this.updateCropBackground();this.drawCroppedImage();},"stopResizingGrid":function(event){event.preventDefault();document.detachEventHandler("mouseup",this.stopResizingGrid.bind(this));document.detachEventHandler("mousemove",this.resizeGrid.bind(this));this.mouseDownElement=null;},"startResizingGrid":function(event){event.preventDefault();this.originalWidth=this.gridHolder.offsetWidth;this.originalHeight=this.gridHolder.offsetHeight;this.originalLeft=this.gridHolder.offsetLeft;this.originalTop=this.gridHolder.offsetTop;this.originalMouseX=event.pageX;this.originalMouseY=event.pageY;this.mouseDownElement=event.currentTarget;document.attachEventHandler("mousemove",this.resizeGrid.bind(this));document.attachEventHandler("mouseup",this.stopResizingGrid.bind(this));},"hideGrid":function(){if(!this.gridHolderStyle.opacity)this.gridHolderStyle.removeProperty("visibility");},"destroy":function(){try{let imageHolder=this.imageToCrop.parentElement;delete this.imageToCrop.jsCropInstance;imageHolder.parentElement.insertBefore(this.imageToCrop,imageHolder);window.detachEventHandler("unload",this.destroy.bind(this));this.gridHolder.detachEventHandler("transitionend",this.hideGrid.bind(this));this.grid.detachEventHandler("mousedown",this.startResizingGrid.bind(this));Object.entries(this.resizers).forEach(function([key,value]){value.detachEventHandler("mousedown",this.startResizingGrid.bind(this));}.bind(this));this.cropResultStyle=null;this.gridHolderStyle=null;this.cropResultContext=null;this.imageOverlayContext=null;Object.entries(this.resizers).forEach(function([key,value]){value.remove();}.bind(this));this.grid.remove();this.gridHolder.remove();this.imageOverlay.remove();imageHolder.remove();this.resizers=null;this.cropResult=null;this.grid=null;this.gridHolder=null;this.imageOverlay=null;this.imageToCrop=null;imageHolder=null;}catch{void(0);}},"initialiseGrid":function(){let imageToCropClientBoundingRect=this.imageToCrop.getBoundingClientRect();let imageWidth=this.imageToCrop.offsetWidth;let imageHeight=this.imageToCrop.offsetHeight;this.imageLeft=imageToCropClientBoundingRect.left;this.imageTop=imageToCropClientBoundingRect.top;this.imageRight=imageToCropClientBoundingRect.right;this.imageBottom=imageToCropClientBoundingRect.bottom;this.imageOverlay.width=imageWidth;this.imageOverlay.height=imageHeight;this.imageOverlayContext=this.imageOverlay.getContext("2d");this.gridHolderStyle=this.gridHolder.style;this.gridHolderStyle.top="20px";this.gridHolderStyle.left="20px";this.gridHolderStyle.width=`${(imageWidth-40)}px`;this.gridHolderStyle.height=`${(imageHeight-40)}px`;this.maxWidth=imageWidth;this.maxHeight=imageHeight;this.maxLeft=(this.maxWidth-this.minWidth);this.maxTop=(this.maxHeight-this.minHeight);Object.entries(this.resizers).forEach(function([key,value]){value.attachEventHandler("mousedown",this.startResizingGrid.bind(this));}.bind(this));this.grid.attachEventHandler("mousedown",this.startResizingGrid.bind(this));this.gridHolder.attachEventHandler("transitionend",this.hideGrid.bind(this));window.attachEventHandler("unload",this.destroy.bind(this));imageToCropClientBoundingRect=null;}};let imageHolder=document.createElement("div");let resizerClassNames=["top-left","top-mid","top-right","right-mid","bot-right","bot-mid","bot-left","left-mid"];let gridTableBody=document.createElement("tbody");let addResizer=function(value,index,source){let resizer=document.createElement("div");let resizerHandle=document.createElement("div");let resizerClassName=`js-crop-resizer js-crop-${value}`;resizer.className=resizerClassName;resizerHandle.className=`${resizerClassName} js-crop-handle`;cropper.resizers[value.replace(/-(.)/g,x=>x[1].toUpperCase())]=resizer;cropper.gridHolder.appendChild(resizerHandle);cropper.gridHolder.appendChild(resizer);resizerHandle=null;resizer=null;};cropper.imageToCrop=imageElement;cropper.imageOverlay=document.createElement("canvas");cropper.gridHolder=document.createElement("div");cropper.grid=document.createElement("table");cropper.gridHolder.classList.add("js-crop-grid-holder");cropper.grid.classList.add("js-crop-grid");imageHolder.classList.add("js-crop-image-holder");resizerClassNames.forEach(addResizer.bind(this));for(let rowLoopIndex=0;rowLoopIndex<=2;rowLoopIndex++){let tableRow=document.createElement("tr");for(let columnLoopIndex=0;columnLoopIndex<=2;columnLoopIndex++)tableRow.appendChild(document.createElement("td"));gridTableBody.appendChild(tableRow);tableRow=null;}cropper.grid.appendChild(gridTableBody);cropper.gridHolder.appendChild(cropper.grid);imageElement.parentElement.insertBefore(imageHolder,imageElement);imageHolder.appendChild(imageElement);imageHolder.appendChild(cropper.imageOverlay);imageHolder.appendChild(cropper.gridHolder);cropper.initialiseGrid();cropper.setOutputCanvas(options.outputCanvas||document.createElement("canvas"));cropper.enableCropMode(!(options.startInCropMode===false));gridTableBody=null;resizerClassNames=null;imageHolder=null;currentInstance=Object.freeze({"enableCropMode":cropper.enableCropMode.bind(cropper),"setOutputCanvas":cropper.setOutputCanvas.bind(cropper),"drawCroppedImage":cropper.drawCroppedImage.bind(cropper),"downloadCroppedImage":cropper.downloadCroppedImage.bind(cropper),"setCropRegion":cropper.setCropRegion.bind(cropper),"destroy":cropper.destroy.bind(cropper)});Object.defineProperty(imageElement,"jsCropInstance",{"value":currentInstance,"configurable":true});}else{currentInstance.destroy();currentInstance=this.initialise(imageElement,options);}return currentInstance;},"getCurrentInstance":function(imageElement){return imageElement.jsCropInstance;}});})();