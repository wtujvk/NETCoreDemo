define("gallery/keymaster/1.6.2/keymaster",[],function(a,b,c){function d(a,b){for(var c=a.length;c--;)if(a[c]===b)return c;return-1}function e(a,b){if(a.length!=b.length)return!1;for(var c=0;c<a.length;c++)if(a[c]!==b[c])return!1;return!0}function f(a){for(v in y)y[v]=a[E[v]]}function g(a){var b,c,e,g,h,i;if(b=a.keyCode,-1==d(D,b)&&D.push(b),(93==b||224==b)&&(b=91),b in y){y[b]=!0;for(e in A)A[e]==b&&(j[e]=!0)}else if(f(a),j.filter.call(this,a)&&b in x)for(i=p(),g=0;g<x[b].length;g++)if(c=x[b][g],c.scope==i||"all"==c.scope){h=c.mods.length>0;for(e in y)(!y[e]&&d(c.mods,+e)>-1||y[e]&&-1==d(c.mods,+e))&&(h=!1);(0!=c.mods.length||y[16]||y[18]||y[17]||y[91])&&!h||c.method(a,c)===!1&&(a.preventDefault?a.preventDefault():a.returnValue=!1,a.stopPropagation&&a.stopPropagation(),a.cancelBubble&&(a.cancelBubble=!0))}}function h(a){var b,c=a.keyCode,e=d(D,c);if(e>=0&&D.splice(e,1),(93==c||224==c)&&(c=91),c in y){y[c]=!1;for(b in A)A[b]==c&&(j[b]=!1)}}function i(){for(v in y)y[v]=!1;for(v in A)j[v]=!1}function j(a,b,c){var d,e;d=r(a),void 0===c&&(c=b,b="all");for(var f=0;f<d.length;f++)e=[],a=d[f].split("+"),a.length>1&&(e=s(a),a=[a[a.length-1]]),a=a[0],a=C(a),a in x||(x[a]=[]),x[a].push({shortcut:d[f],scope:b,method:c,key:d[f],mods:e})}function k(a,b){var c,d,f,g,h,i=[];for(c=r(a),g=0;g<c.length;g++){if(d=c[g].split("+"),d.length>1&&(i=s(d),a=d[d.length-1]),a=C(a),void 0===b&&(b=p()),!x[a])return;for(f=0;f<x[a].length;f++)h=x[a][f],h.scope===b&&e(h.mods,i)&&(x[a][f]={})}}function l(a){return"string"==typeof a&&(a=C(a)),-1!=d(D,a)}function m(){return D.slice(0)}function n(a){var b=(a.target||a.srcElement).tagName;return!("INPUT"==b||"SELECT"==b||"TEXTAREA"==b)}function o(a){z=a||"all"}function p(){return z||"all"}function q(a){var b,c,d;for(b in x)for(c=x[b],d=0;d<c.length;)c[d].scope===a?c.splice(d,1):d++}function r(a){var b;return a=a.replace(/\s/g,""),b=a.split(","),""==b[b.length-1]&&(b[b.length-2]+=","),b}function s(a){for(var b=a.slice(0,a.length-1),c=0;c<b.length;c++)b[c]=A[b[c]];return b}function t(a,b,c){a.addEventListener?a.addEventListener(b,c,!1):a.attachEvent&&a.attachEvent("on"+b,function(){c(window.event)})}function u(){var a=w.key;return w.key=F,a}var v,w={},x={},y={16:!1,18:!1,17:!1,91:!1},z="all",A={"⇧":16,shift:16,"⌥":18,alt:18,option:18,"⌃":17,ctrl:17,control:17,"⌘":91,command:91},B={backspace:8,tab:9,clear:12,enter:13,"return":13,esc:27,escape:27,space:32,left:37,up:38,right:39,down:40,del:46,"delete":46,home:36,end:35,pageup:33,pagedown:34,",":188,".":190,"/":191,"`":192,"-":189,"=":187,";":186,"'":222,"[":219,"]":221,"\\":220},C=function(a){return B[a]||a.toUpperCase().charCodeAt(0)},D=[];for(v=1;20>v;v++)B["f"+v]=111+v;var E={16:"shiftKey",18:"altKey",17:"ctrlKey",91:"metaKey"};for(v in A)j[v]=!1;t(document,"keydown",function(a){g(a)}),t(document,"keyup",h),t(window,"focus",i);var F=w.key;w.key=j,w.key.setScope=o,w.key.getScope=p,w.key.deleteScope=q,w.key.filter=n,w.key.isPressed=l,w.key.getPressedKeyCodes=m,w.key.noConflict=u,w.key.unbind=k,"undefined"!=typeof c&&(c.exports=w.key)});