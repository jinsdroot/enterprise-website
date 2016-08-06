//// JScript File
var DIV_BG_COLOR ="#d6f1f8";//c0c0ff";// "#FFE0C0";
var DIV_HIGHLIGHT_COLOR ="#ffffcc";//"#c0c0ff";// "#6699FF";
var ITEM_COLOR="#000000";             
var ITEM_HIGHLIGHT_COLOR="#009900";
var DIV_FONT = "Arial";
var DIV_PADDING = "2px";
var DIV_BORDER = "1px solid #CCC";
var queryField;
var divName;
var ifName;
var lastVal = "";
var val = "";
var globalDiv;
var divFormatted = false;

function AutoIni( queryFieldName, hiddenDivName )
{    
    queryField = document.getElementById( queryFieldName );
    queryField.onblur = hideDiv;
    queryField.onkeydown = keypressHandler;
    queryField.autocomplete = "off";
    
    if( hiddenDivName )
    {
        divName = hiddenDivName;
    }
    else
    {
        divName = "querydiv";
    }
    
    ifName = "queryiframe";
    setTimeout("mainLoop();",100);
}

function getDiv(divID)
{
    if(!globalDiv)
    {
        if(!document.getElementById(divID))
        {
            var newNode = document.createElement("div");
            newNode.setAttribute("id", divID);
            document.body.appendChild(newNode);
        }
        globalDiv = document.getElementById(divID);
        var x = queryField.offsetLeft;
        var y = queryField.offsetTop + queryField.offsetHeight;
        var parent = queryField;
        while(parent.offsetParent)
        {
            parent = parent.offsetParent;
            x += parent.offsetLeft;
            y += parent.offsetTop;
        }
        if(!divFormatted)
        {
            globalDiv.style.backgroundColor = DIV_BG_COLOR;
            globalDiv.style.fontFamily = DIV_FONT;
            globalDiv.style.padding = DIV_PADDING;
            globalDiv.style.border = DIV_BORDER;
            globalDiv.style.width =queryField.style.width;
            globalDiv.style.fontSize = "90%";            
            globalDiv.style.position = "absolute";
            globalDiv.style.left = x + "px";
            globalDiv.style.top = y + "px";
            globalDiv.style.visibility = "hidden";
            globalDiv.style.zIndex = 10000;
            
            divFormatted = true;
			
        }
    }
    return globalDiv;
}

function showQueryDiv(resultArray)
{
    var div = getDiv(divName);
    while( div.childNodes.length > 0 )
    {
        div.removeChild(div.childNodes[0]);
    }
    try{
        for(var i = 0; i < resultArray.length; i++)
        {
            var result = document.createElement("div");
            result.style.cursor = "pointer";
            result.style.padding = "2px 0px 2px 0px";
            result.style.width = div.style.width; 
           
            _unhighlightResult(result);
            result.onmousedown = selectResult;
            result.onmouseover = highlightResult;
            result.onmouseout = unhighlightResult;        
            
            var value = document.createElement("span");
            value.className = "value";
            value.style.textAlign = "left";
            value.style.fontWeight = "bold";        
            value.innerHTML = resultArray[i];
            result.appendChild(value);
            div.appendChild(result);        
        }
        showDiv(resultArray.length > 0);
    }
    catch(e)
    {
        return;
    }
}

function selectResult()
{
    _selectResult(this);
   
}
function _selectResult( item )
{
    var spans = item.getElementsByTagName("span");
    if( spans )
    {
        for(var i = 0; i < spans.length; i++)
        {
            if( spans[i].className == "value" )
            {
                queryField.value = spans[i].innerHTML;
                lastVal = val =  queryField.value ;
                mainLoop();
                queryField.focus();
                showDiv( false );
                 if(queryField.onchange!=null)
                    queryField.onchange();
                return;
            }
        }
    }
}

function highlightResult()
{
    _highlightResult( this );    
}

function _highlightResult( item )
{
    item.style.backgroundColor = DIV_HIGHLIGHT_COLOR;
    item.style.color=ITEM_HIGHLIGHT_COLOR;//"#009900";//"#00ffff";  //项的文字颜色
}

function unhighlightResult()
{
    _unhighlightResult( this );
}

function _unhighlightResult( item )
{
    item.style.backgroundColor = DIV_BG_COLOR;
    item.style.color=ITEM_COLOR;//"#000000";
}

function showDiv( show )
{
    var div = getDiv( divName );
    if( show )
    {
        div.style.visibility = "visible";
    }
    else
    {
        div.style.visibility = "hidden";
    }
    adjustiFrame();
}

function hideDiv()
{
    showDiv( false );
}

function keypressHandler(evt)
{
    
    var div = getDiv( divName );
   
    
    if( div.style.visibility == "hidden" )
    {
        return true;
    }
    if( !evt && window.event )
    {
        evt = window.event;
    }
    var key = evt.keyCode;
    
    var KEYUP = 38;
    var KEYDOWN = 40;
    var KEYENTER = 13;
    var KEYTAB = 9;
    if(( key != KEYUP ) && ( key != KEYDOWN ) && ( key != KEYENTER ) && ( key != KEYTAB ))
    {
        return true;
    }
    var selNum = getSelectedSpanNum( div );
    var selSpan = setSelectedSpan( div, selNum );
    if( key == KEYENTER || key == KEYTAB )
    {
        if( selSpan )
        {
            _selectResult(selSpan);
        }
        evt.cancelBubble= true;
        
         if(window.event.keyCode==13)
        {
            window.event.keyCode=9 ;
            hideDiv();
            return true;
        }
        //return false;
    }    
    else
    {
        if( key == KEYUP)
        {
            selSpan = setSelectedSpan( div, selNum - 1 );           
        }
        if( key == KEYDOWN )
        {
            selSpan = setSelectedSpan( div, selNum + 1 );
        }
        if( selSpan )
        {
            _highlightResult( selSpan );
        }
    }
    showDiv( true );
    return true;
}

function getSelectedSpanNum( div )
{
    var count = -1;
    var spans = div.getElementsByTagName("div");
    if( spans )
    {
        for( var i = 0; i < spans.length; i++)
        {
            count++;
            if( spans[i].style.backgroundColor != div.style.backgroundColor )
            {
                return count;
            }
        }
    }
    return -1;
}
function setSelectedSpan( div, spanNum )
{
    var count = -1;
    var thisDiv;
    var divs = div.getElementsByTagName("div");
    if( divs )
    {
        for( var i = 0; i < divs.length; i++ )
        {
            if( ++count == spanNum )
            {
                _highlightResult( divs[i] );
                thisDiv = divs[i];
            }
            else
            {
                _unhighlightResult( divs[i] );
            }
        }        
    }
    return thisDiv;
}

function adjustiFrame()
{
    if(!document.getElementById(ifName))
    {
        var newNode = document.createElement("iFrame");
        newNode.setAttribute("id", ifName);
        newNode.setAttribute("src","javascript:false;");
        newNode.setAttribute("scrolling","no");
        newNode.setAttribute("frameborder","0");
        document.body.appendChild( newNode );		
    }
    iFrameDiv = document.getElementById( ifName );
    var div = getDiv( divName );    
    try
    {
        iFrameDiv.style.position = "absolute";        
        iFrameDiv.style.width = div.offsetWidth;
        iFrameDiv.style.height = div.offsetHeight;
        iFrameDiv.style.top = div.style.top;
        iFrameDiv.style.left = div.style.left;
        iFrameDiv.style.zIndex = div.style.zIndex - 1;
        iFrameDiv.style.visibility = div.style.visibility; 
    }
    catch (e)
    {}
}

