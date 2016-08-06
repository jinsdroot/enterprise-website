function CheckAll(oCheckbox,id)//全选
   {       
        var oGridView = document.getElementById(id);
       for(i = 0;i < oGridView.rows.length; i++)
       {
           obj= oGridView.rows[i].cells[0].getElementsByTagName("INPUT")[0];
           if(obj!=null)
           {
               obj.checked = true;//  oCheckbox.checked;
           }
        }    
   }
   
   function InverseSel(id) //反选
   {
       var oGridView = document.getElementById(id);
       for(i = 0;i < oGridView.rows.length; i++)
       {
           obj= oGridView.rows[i].cells[0].getElementsByTagName("INPUT")[0];
           if(obj!=null)
           {
                obj.checked = !obj.checked;
           }
        }    
   }

