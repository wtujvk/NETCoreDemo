define("gallery/store/1.3.16/store",["gallery/json/1.0.3/json"],function(a,b,c){a("gallery/json/1.0.3/json"),function(a){function b(){try{return i in a&&a[i]}catch(b){return!1}}function d(a){return function(){var b=Array.prototype.slice.call(arguments,0);b.unshift(f),k.appendChild(f),f.addBehavior("#default#userData"),f.load(i);var c=a.apply(g,b);return k.removeChild(f),c}}function e(a){return a.replace(/^d/,"___$&").replace(n,"___")}var f,g={},h=a.document,i="localStorage",j="script";if(g.disabled=!1,g.set=function(){},g.get=function(){},g.remove=function(){},g.clear=function(){},g.transact=function(a,b,c){var d=g.get(a);null==c&&(c=b,b=null),"undefined"==typeof d&&(d=b||{}),c(d),g.set(a,d)},g.getAll=function(){},g.forEach=function(){},g.serialize=function(a){return JSON.stringify(a)},g.deserialize=function(a){if("string"!=typeof a)return void 0;try{return JSON.parse(a)}catch(b){return a||void 0}},b())f=a[i],g.set=function(a,b){return void 0===b?g.remove(a):(f.setItem(a,g.serialize(b)),b)},g.get=function(a){return g.deserialize(f.getItem(a))},g.remove=function(a){f.removeItem(a)},g.clear=function(){f.clear()},g.getAll=function(){var a={};return g.forEach(function(b,c){a[b]=c}),a},g.forEach=function(a){for(var b=0;b<f.length;b++){var c=f.key(b);a(c,g.get(c))}};else if(h.documentElement.addBehavior){var k,l;try{l=new ActiveXObject("htmlfile"),l.open(),l.write("<"+j+">document.w=window</"+j+'><iframe src="/favicon.ico"></iframe>'),l.close(),k=l.w.frames[0].document,f=k.createElement("div")}catch(m){f=h.createElement("div"),k=h.body}var n=new RegExp("[!\"#$%&'()*+,/\\\\:;<=>?@[\\]^`{|}~]","g");g.set=d(function(a,b,c){return b=e(b),void 0===c?g.remove(b):(a.setAttribute(b,g.serialize(c)),a.save(i),c)}),g.get=d(function(a,b){return b=e(b),g.deserialize(a.getAttribute(b))}),g.remove=d(function(a,b){b=e(b),a.removeAttribute(b),a.save(i)}),g.clear=d(function(a){var b=a.XMLDocument.documentElement.attributes;a.load(i);for(var c,d=0;c=b[d];d++)a.removeAttribute(c.name);a.save(i)}),g.getAll=function(){var a={};return g.forEach(function(b,c){a[b]=c}),a},g.forEach=d(function(a,b){for(var c,d=a.XMLDocument.documentElement.attributes,e=0;c=d[e];++e)b(c.name,g.deserialize(a.getAttribute(c.name)))})}try{var o="__storejs__";g.set(o,o),g.get(o)!=o&&(g.disabled=!0),g.remove(o)}catch(m){g.disabled=!0}g.enabled=!g.disabled,"undefined"!=typeof c&&c.exports&&this.module!==c?c.exports=g:"function"==typeof define&&define.amd?define(g):a.store=g}(Function("return this")())});