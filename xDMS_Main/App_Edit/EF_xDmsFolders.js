<script type="text/javascript"> 
var script_xDmsFolders = {
    ACEParentFolderID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ParentFolderID','');
      var F_ParentFolderID = $get(sender._element.id);
      var F_ParentFolderID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ParentFolderID.value = p[0];
      F_ParentFolderID_Display.innerHTML = e.get_text();
    },
    ACEParentFolderID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ParentFolderID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEParentFolderID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEStatusBy_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('StatusBy','');
      var F_StatusBy = $get(sender._element.id);
      var F_StatusBy_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_StatusBy.value = p[0];
      F_StatusBy_Display.innerHTML = e.get_text();
    },
    ACEStatusBy_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('StatusBy','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEStatusBy_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEReleaseWorkflowID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReleaseWorkflowID','');
      var F_ReleaseWorkflowID = $get(sender._element.id);
      var F_ReleaseWorkflowID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReleaseWorkflowID.value = p[0];
      F_ReleaseWorkflowID_Display.innerHTML = e.get_text();
    },
    ACEReleaseWorkflowID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReleaseWorkflowID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReleaseWorkflowID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEReviseWorkflowID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReviseWorkflowID','');
      var F_ReviseWorkflowID = $get(sender._element.id);
      var F_ReviseWorkflowID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReviseWorkflowID.value = p[0];
      F_ReviseWorkflowID_Display.innerHTML = e.get_text();
    },
    ACEReviseWorkflowID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReviseWorkflowID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReviseWorkflowID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEInitialWorkflowID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('InitialWorkflowID','');
      var F_InitialWorkflowID = $get(sender._element.id);
      var F_InitialWorkflowID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_InitialWorkflowID.value = p[0];
      F_InitialWorkflowID_Display.innerHTML = e.get_text();
    },
    ACEInitialWorkflowID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('InitialWorkflowID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEInitialWorkflowID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ParentFolderID: function(sender) {
      var Prefix = sender.id.replace('ParentFolderID','');
      this.validated_FK_xDMS_Folders_ParentFolderID_main = true;
      this.validate_FK_xDMS_Folders_ParentFolderID(sender,Prefix);
      },
    validate_StatusBy: function(sender) {
      var Prefix = sender.id.replace('StatusBy','');
      this.validated_FK_xDMS_Folders_StatusBy_main = true;
      this.validate_FK_xDMS_Folders_StatusBy(sender,Prefix);
      },
    validate_ReleaseWorkflowID: function(sender) {
      var Prefix = sender.id.replace('ReleaseWorkflowID','');
      this.validated_FK_xDMS_Folders_ReleaseWorkflowID_main = true;
      this.validate_FK_xDMS_Folders_ReleaseWorkflowID(sender,Prefix);
      },
    validate_ReviseWorkflowID: function(sender) {
      var Prefix = sender.id.replace('ReviseWorkflowID','');
      this.validated_FK_xDMS_Folders_ReviseWorkflowID_main = true;
      this.validate_FK_xDMS_Folders_ReviseWorkflowID(sender,Prefix);
      },
    validate_InitialWorkflowID: function(sender) {
      var Prefix = sender.id.replace('InitialWorkflowID','');
      this.validated_FK_xDMS_Folders_InitialWorkflowID_main = true;
      this.validate_FK_xDMS_Folders_InitialWorkflowID(sender,Prefix);
      },
    validate_FK_xDMS_Folders_StatusBy: function(o,Prefix) {
      var value = o.id;
      var StatusBy = $get(Prefix + 'StatusBy');
      if(StatusBy.value==''){
        if(this.validated_FK_xDMS_Folders_StatusBy_main){
          var o_d = $get(Prefix + 'StatusBy' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + StatusBy.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Folders_StatusBy(value, this.validated_FK_xDMS_Folders_StatusBy);
      },
    validated_FK_xDMS_Folders_StatusBy_main: false,
    validated_FK_xDMS_Folders_StatusBy: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolders.validated_FK_xDMS_Folders_StatusBy_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Folders_ParentFolderID: function(o,Prefix) {
      var value = o.id;
      var ParentFolderID = $get(Prefix + 'ParentFolderID');
      if(ParentFolderID.value==''){
        if(this.validated_FK_xDMS_Folders_ParentFolderID_main){
          var o_d = $get(Prefix + 'ParentFolderID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ParentFolderID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Folders_ParentFolderID(value, this.validated_FK_xDMS_Folders_ParentFolderID);
      },
    validated_FK_xDMS_Folders_ParentFolderID_main: false,
    validated_FK_xDMS_Folders_ParentFolderID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolders.validated_FK_xDMS_Folders_ParentFolderID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Folders_ReleaseWorkflowID: function(o,Prefix) {
      var value = o.id;
      var ReleaseWorkflowID = $get(Prefix + 'ReleaseWorkflowID');
      if(ReleaseWorkflowID.value==''){
        if(this.validated_FK_xDMS_Folders_ReleaseWorkflowID_main){
          var o_d = $get(Prefix + 'ReleaseWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReleaseWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Folders_ReleaseWorkflowID(value, this.validated_FK_xDMS_Folders_ReleaseWorkflowID);
      },
    validated_FK_xDMS_Folders_ReleaseWorkflowID_main: false,
    validated_FK_xDMS_Folders_ReleaseWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolders.validated_FK_xDMS_Folders_ReleaseWorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Folders_ReviseWorkflowID: function(o,Prefix) {
      var value = o.id;
      var ReviseWorkflowID = $get(Prefix + 'ReviseWorkflowID');
      if(ReviseWorkflowID.value==''){
        if(this.validated_FK_xDMS_Folders_ReviseWorkflowID_main){
          var o_d = $get(Prefix + 'ReviseWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReviseWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Folders_ReviseWorkflowID(value, this.validated_FK_xDMS_Folders_ReviseWorkflowID);
      },
    validated_FK_xDMS_Folders_ReviseWorkflowID_main: false,
    validated_FK_xDMS_Folders_ReviseWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolders.validated_FK_xDMS_Folders_ReviseWorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Folders_InitialWorkflowID: function(o,Prefix) {
      var value = o.id;
      var InitialWorkflowID = $get(Prefix + 'InitialWorkflowID');
      if(InitialWorkflowID.value==''){
        if(this.validated_FK_xDMS_Folders_InitialWorkflowID_main){
          var o_d = $get(Prefix + 'InitialWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + InitialWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Folders_InitialWorkflowID(value, this.validated_FK_xDMS_Folders_InitialWorkflowID);
      },
    validated_FK_xDMS_Folders_InitialWorkflowID_main: false,
    validated_FK_xDMS_Folders_InitialWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolders.validated_FK_xDMS_Folders_InitialWorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FolderName: function(o,p,q) {                                                                     
      var value = o.id;                                                                                         
      try{$get('L_ErrMsgxDmsFolders').innerHTML = '';}catch(ex){}   
      if(o.value=='')                                                                                
        return true;     
      value = value + ',' + o.value + ','+p +','+q;                                                                
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';                                              
      o.style.backgroundRepeat= 'no-repeat';                                                                    
      o.style.backgroundPosition = 'right';                                                                     
      PageMethods.validate_FolderName(value, this.validated_FolderName);                              
    },                                                                                                          
    validated_FolderName: function(result) {                                                               
      var p = result.split('|');                                                                                
      var o = $get(p[1]);                                                                                       
      o.style.backgroundImage  = 'none';                                                                        
      if(p[0]=='1'){                                                                                            
        try{$get('L_ErrMsgxDmsFolders').innerHTML = p[2];}catch(ex){}
        o.value='';                                                                                             
        o.focus();                                                                                              
      }
    },        
    ACEStatusID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('StatusID','');
      var F_StatusID = $get(sender._element.id);
      var F_StatusID_Display = $get(sender._element.id + '_Display');
      var retval = (!e._value)?e._item.parentElement.parentElement._value:e._value;
      var p = retval.split('|');
      F_StatusID.value = p[0];
      F_StatusID_Display.innerHTML = e.get_text();
    },
    ACEStatusID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('StatusID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEStatusID_Populated: function(sender,e) {
      var x =sender._completionListElement.childNodes;
      for(var i=0, h; h= x[i];i++){
        h.innerHTML = h.innerText;
      }
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_StatusID: function(sender) {
      var Prefix = sender.id.replace('StatusID','');
      this.validated_FK_xDMS_Folders_StatusID_main = true;
      this.validate_FK_xDMS_Folders_StatusID(sender,Prefix);
    },
    validate_FK_xDMS_Folders_StatusID: function(o,Prefix) {
      var value = o.id;
      var StatusID = $get(Prefix + 'StatusID');
      if(StatusID.value==''){
        if(this.validated_FK_xDMS_Folders_StatusID_main){
          var o_d = $get(Prefix + 'StatusID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + StatusID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validate_FK_xDMS_Folders_StatusID(value, this.validated_FK_xDMS_Folders_StatusID);
    },
    validated_FK_xDMS_Folders_StatusID_main: false,
    validated_FK_xDMS_Folders_StatusID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolders.validated_FK_xDMS_Folders_StatusID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    ACEUploadedStatusID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UploadedStatusID','');
      var F_UploadedStatusID = $get(sender._element.id);
      var F_UploadedStatusID_Display = $get(sender._element.id + '_Display');
      var retval = (!e._value)?e._item.parentElement.parentElement._value:e._value;
      var p = retval.split('|');
      F_UploadedStatusID.value = p[0];
      F_UploadedStatusID_Display.innerHTML = e.get_text();
    },
    ACEUploadedStatusID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UploadedStatusID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUploadedStatusID_Populated: function(sender,e) {
      var x =sender._completionListElement.childNodes;
      for(var i=0, h; h= x[i];i++){
        h.innerHTML = h.innerText;
      }
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_UploadedStatusID: function(sender) {
      var Prefix = sender.id.replace('UploadedStatusID','');
      this.validated_FK_xDMS_Folders_UploadedStatusID_main = true;
      this.validate_FK_xDMS_Folders_UploadedStatusID(sender,Prefix);
    },
    validate_FK_xDMS_Folders_UploadedStatusID: function(o,Prefix) {
      var value = o.id;
      var UploadedStatusID = $get(Prefix + 'UploadedStatusID');
      if(UploadedStatusID.value==''){
        if(this.validated_FK_xDMS_Folders_UploadedStatusID_main){
          var o_d = $get(Prefix + 'UploadedStatusID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UploadedStatusID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validate_FK_xDMS_Folders_UploadedStatusID(value, this.validated_FK_xDMS_Folders_UploadedStatusID);
    },
    validated_FK_xDMS_Folders_UploadedStatusID_main: false,
    validated_FK_xDMS_Folders_UploadedStatusID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolders.validated_FK_xDMS_Folders_UploadedStatusID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
