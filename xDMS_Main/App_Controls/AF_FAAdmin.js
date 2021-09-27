<script type="text/javascript"> 
var script_xDmsFolderAuthorizations = {
    ACEUserID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UserID','');
      var F_UserID = $get(sender._element.id);
      var F_UserID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UserID.value = p[0];
      F_UserID_Display.innerHTML = e.get_text();
    },
    ACEUserID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UserID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUserID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEFolderID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FolderID','');
      var F_FolderID = $get(sender._element.id);
      var F_FolderID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FolderID.value = p[0];
      F_FolderID_Display.innerHTML = e.get_text();
    },
    ACEFolderID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FolderID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFolderID_Populated: function(sender,e) {
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
    ACEUploadedStatusID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UploadedStatusID','');
      var F_UploadedStatusID = $get(sender._element.id);
      var F_UploadedStatusID_Display = $get(sender._element.id + '_Display');
      var retval = (!e._value) ? e._item.parentElement.parentElement._value : e._value;
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
      var x = sender._completionListElement.childNodes;for (var i = 0, h; h = x[i]; i++) {h.innerHTML = h.innerText;}
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_UserID: function(sender,q) {
      var Prefix = sender.id.replace('UserID','');
      this.validated_FK_xDMS_FolderAuthorizations_UserID_main = true;
      this.validate_FK_xDMS_FolderAuthorizations_UserID(sender,Prefix,q);
      },
    validate_FolderID: function(sender) {
      var Prefix = sender.id.replace('FolderID','');
      this.validated_FK_xDMS_FolderAuthorizations_FolderID_main = true;
      this.validate_FK_xDMS_FolderAuthorizations_FolderID(sender,Prefix);
      },
    validate_ReleaseWorkflowID: function(sender) {
      var Prefix = sender.id.replace('ReleaseWorkflowID','');
      this.validated_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID_main = true;
      this.validate_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID(sender,Prefix);
      },
    validate_ReviseWorkflowID: function(sender) {
      var Prefix = sender.id.replace('ReviseWorkflowID','');
      this.validated_FK_xDMS_FolderAuthorizations_ReviseWorkflowID_main = true;
      this.validate_FK_xDMS_FolderAuthorizations_ReviseWorkflowID(sender,Prefix);
      },
    validate_InitialWorkflowID: function(sender) {
      var Prefix = sender.id.replace('InitialWorkflowID','');
      this.validated_FK_xDMS_FolderAuthorizations_InitialWorkflowID_main = true;
      this.validate_FK_xDMS_FolderAuthorizations_InitialWorkflowID(sender,Prefix);
      },
    validate_UploadedStatusID: function(sender) {
      var Prefix = sender.id.replace('UploadedStatusID','');
      this.validated_FK_xDMS_FolderAuthorizations_UploadedStatusID_main = true;
      this.validate_FK_xDMS_FolderAuthorizations_UploadedStatusID(sender,Prefix);
      },
    validate_FK_xDMS_FolderAuthorizations_UserID: function(o,Prefix,q) {
      var value = o.id;
      var UserID = $get(Prefix + 'UserID');
      if(UserID.value==''){
        if(this.validated_FK_xDMS_FolderAuthorizations_UserID_main){
          var o_d = $get(Prefix + 'UserID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserID.value+','+q ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FolderAuthorizations_UserID(value, this.validated_FK_xDMS_FolderAuthorizations_UserID);
      },
    validated_FK_xDMS_FolderAuthorizations_UserID_main: false,
    validated_FK_xDMS_FolderAuthorizations_UserID: function(result) {
      var p = JSON.parse(result);
      var o = $get(p.key);
      if(script_xDmsFolderAuthorizations.validated_FK_xDMS_FolderAuthorizations_UserID_main){
        var o_d = $get(p.key+'_Display');
        try{o_d.innerHTML = p.msg;}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p.err){
        o.value='';
        o.focus();
      }else{
        if(p.data=='null') 
          return;
        try{
        var oj = p.data;
        $get('F_UserID').value=oj.UserID;
        $get('F_UserID_Display').innerText=oj.aspnet_Users2_UserFullName;
        $get('F_FolderID').value=oj.FolderID;
        $get('F_FolderID_Display').innerText=oj.xDMS_Folders3_FolderName;
        $get('F_CreateFolder').checked=oj.CreateFolder;
        $get('F_UpdateFolder').checked=oj.UpdateFolder;
        $get('F_DeleteFolder').checked=oj.DeleteFolder;
        $get('F_UploadFile').checked=oj.UploadFile;
        $get('F_DownloadFile').checked=oj.DownloadFile;
        $get('F_DeleteFile').checked=oj.DeleteFile;
        $get('F_CanAuthorizeFolder').checked=oj.CanAuthorizeFolder;
        $get('F_CanPassAuthorization').checked=oj.CanPassAuthorization;
        $get('F_CanViewAllRevisions').checked=oj.CanViewAllRevisions;
        $get('F_RequireExplicitAuthorization').checked=oj.RequireExplicitAuthorization;
        $get('F_RequireExplicitWorkflow').checked=oj.RequireExplicitWorkflow;
        $get('F_ReleaseWorkflowID').value=oj.ReleaseWorkflowID;
        $get('F_ReleaseWorkflowID_Display').innerText=oj.xDMS_Workflows6_WorkflowName;
        $get('F_ReviseWorkflowID').value=oj.ReviseWorkflowID;
        $get('F_ReviseWorkflowID_Display').innerText=oj.xDMS_Workflows7_WorkflowName;
        $get('F_InitialWorkflowID').value=oj.InitialWorkflowID;
        $get('F_InitialWorkflowID_Display').innerText=oj.xDMS_Workflows9_WorkflowName;
        $get('F_UploadedStatusID').value=oj.UploadedStatusID;
        $get('F_UploadedStatusID_Display').innerText=oj.xDMS_States8_StatusName;
        $get('F_UseFileTypeWorkflow').checked=oj.UseFileTypeWorkflow;
        $get('F_DuplicateFileNameAllowed').checked=oj.DuplicateFileNameAllowed;
        $get('F_ShowAtRoot').checked=oj.ShowAtRoot;
        $get('F_IsAdmin').checked=oj.IsAdmin;

        }catch(ex){}
      }
    },
    validate_FK_xDMS_FolderAuthorizations_FolderID: function(o,Prefix) {
      var value = o.id;
      var FolderID = $get(Prefix + 'FolderID');
      if(FolderID.value==''){
        if(this.validated_FK_xDMS_FolderAuthorizations_FolderID_main){
          var o_d = $get(Prefix + 'FolderID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FolderID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FolderAuthorizations_FolderID(value, this.validated_FK_xDMS_FolderAuthorizations_FolderID);
      },
    validated_FK_xDMS_FolderAuthorizations_FolderID_main: false,
    validated_FK_xDMS_FolderAuthorizations_FolderID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolderAuthorizations.validated_FK_xDMS_FolderAuthorizations_FolderID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID: function(o,Prefix) {
      var value = o.id;
      var ReleaseWorkflowID = $get(Prefix + 'ReleaseWorkflowID');
      if(ReleaseWorkflowID.value==''){
        if(this.validated_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID_main){
          var o_d = $get(Prefix + 'ReleaseWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReleaseWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID(value, this.validated_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID);
      },
    validated_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID_main: false,
    validated_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolderAuthorizations.validated_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_FolderAuthorizations_ReviseWorkflowID: function(o,Prefix) {
      var value = o.id;
      var ReviseWorkflowID = $get(Prefix + 'ReviseWorkflowID');
      if(ReviseWorkflowID.value==''){
        if(this.validated_FK_xDMS_FolderAuthorizations_ReviseWorkflowID_main){
          var o_d = $get(Prefix + 'ReviseWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReviseWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FolderAuthorizations_ReviseWorkflowID(value, this.validated_FK_xDMS_FolderAuthorizations_ReviseWorkflowID);
      },
    validated_FK_xDMS_FolderAuthorizations_ReviseWorkflowID_main: false,
    validated_FK_xDMS_FolderAuthorizations_ReviseWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolderAuthorizations.validated_FK_xDMS_FolderAuthorizations_ReviseWorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_FolderAuthorizations_UploadedStatusID: function(o,Prefix) {
      var value = o.id;
      var UploadedStatusID = $get(Prefix + 'UploadedStatusID');
      if(UploadedStatusID.value==''){
        if(this.validated_FK_xDMS_FolderAuthorizations_UploadedStatusID_main){
          var o_d = $get(Prefix + 'UploadedStatusID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UploadedStatusID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FolderAuthorizations_UploadedStatusID(value, this.validated_FK_xDMS_FolderAuthorizations_UploadedStatusID);
      },
    validated_FK_xDMS_FolderAuthorizations_UploadedStatusID_main: false,
    validated_FK_xDMS_FolderAuthorizations_UploadedStatusID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolderAuthorizations.validated_FK_xDMS_FolderAuthorizations_UploadedStatusID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_FolderAuthorizations_InitialWorkflowID: function(o,Prefix) {
      var value = o.id;
      var InitialWorkflowID = $get(Prefix + 'InitialWorkflowID');
      if(InitialWorkflowID.value==''){
        if(this.validated_FK_xDMS_FolderAuthorizations_InitialWorkflowID_main){
          var o_d = $get(Prefix + 'InitialWorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + InitialWorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FolderAuthorizations_InitialWorkflowID(value, this.validated_FK_xDMS_FolderAuthorizations_InitialWorkflowID);
      },
    validated_FK_xDMS_FolderAuthorizations_InitialWorkflowID_main: false,
    validated_FK_xDMS_FolderAuthorizations_InitialWorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFolderAuthorizations.validated_FK_xDMS_FolderAuthorizations_InitialWorkflowID_main){
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
