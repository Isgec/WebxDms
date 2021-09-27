<script type="text/javascript"> 
var script_xDmsHFiles = {
    ACEItemTypeID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ItemTypeID','');
      var F_ItemTypeID = $get(sender._element.id);
      var F_ItemTypeID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ItemTypeID.value = p[0];
      F_ItemTypeID_Display.innerHTML = e.get_text();
    },
    ACEItemTypeID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ItemTypeID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEItemTypeID_Populated: function(sender,e) {
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
    ACEStatusID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('StatusID','');
      var F_StatusID = $get(sender._element.id);
      var F_StatusID_Display = $get(sender._element.id + '_Display');
      var retval = (!e._value) ? e._item.parentElement.parentElement._value : e._value;
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
      var x = sender._completionListElement.childNodes;
      for (var i = 0, h; h = x[i]; i++) {
        h.innerHTML = h.innerText;
      }
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
    ACEFileTypeID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FileTypeID','');
      var F_FileTypeID = $get(sender._element.id);
      var F_FileTypeID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FileTypeID.value = p[0];
      F_FileTypeID_Display.innerHTML = e.get_text();
    },
    ACEFileTypeID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FileTypeID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFileTypeID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEWorkflowID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('WorkflowID','');
      var F_WorkflowID = $get(sender._element.id);
      var F_WorkflowID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_WorkflowID.value = p[0];
      F_WorkflowID_Display.innerHTML = e.get_text();
    },
    ACEWorkflowID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('WorkflowID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEWorkflowID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEWorkflowStepID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('WorkflowStepID','');
      var F_WorkflowStepID = $get(sender._element.id);
      var F_WorkflowStepID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_WorkflowStepID.value = p[0];
      F_WorkflowStepID_Display.innerHTML = e.get_text();
    },
    ACEWorkflowStepID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('WorkflowStepID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEWorkflowStepID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEWorkflowNextStepID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('WorkflowNextStepID','');
      var F_WorkflowNextStepID = $get(sender._element.id);
      var F_WorkflowNextStepID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_WorkflowNextStepID.value = p[0];
      F_WorkflowNextStepID_Display.innerHTML = e.get_text();
    },
    ACEWorkflowNextStepID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('WorkflowNextStepID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEWorkflowNextStepID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
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
    ACEGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('GroupID','');
      var F_GroupID = $get(sender._element.id);
      var F_GroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_GroupID.value = p[0];
      F_GroupID_Display.innerHTML = e.get_text();
    },
    ACEGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('GroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ItemTypeID: function(sender) {
      var Prefix = sender.id.replace('ItemTypeID','');
      this.validated_FK_xDMS_HFiles_ItemTypeID_main = true;
      this.validate_FK_xDMS_HFiles_ItemTypeID(sender,Prefix);
      },
    validate_FolderID: function(sender) {
      var Prefix = sender.id.replace('FolderID','');
      this.validated_FK_xDMS_HFiles_FolderID_main = true;
      this.validate_FK_xDMS_HFiles_FolderID(sender,Prefix);
      },
    validate_StatusID: function(sender) {
      var Prefix = sender.id.replace('StatusID','');
      this.validated_FK_xDMS_HFiles_StatusID_main = true;
      this.validate_FK_xDMS_HFiles_StatusID(sender,Prefix);
      },
    validate_StatusBy: function(sender) {
      var Prefix = sender.id.replace('StatusBy','');
      this.validated_FK_xDMS_HFiles_StatusBy_main = true;
      this.validate_FK_xDMS_HFiles_StatusBy(sender,Prefix);
      },
    validate_FileTypeID: function(sender) {
      var Prefix = sender.id.replace('FileTypeID','');
      this.validated_FK_xDMS_HFiles_FileTypeID_main = true;
      this.validate_FK_xDMS_HFiles_FileTypeID(sender,Prefix);
      },
    validate_WorkflowID: function(sender) {
      var Prefix = sender.id.replace('WorkflowID','');
      this.validated_FK_xDMS_HFiles_WorkflowID_main = true;
      this.validate_FK_xDMS_HFiles_WorkflowID(sender,Prefix);
      },
    validate_WorkflowStepID: function(sender) {
      var Prefix = sender.id.replace('WorkflowStepID','');
      this.validated_FK_xDMS_HFiles_WorkflowStepID_main = true;
      this.validate_FK_xDMS_HFiles_WorkflowStepID(sender,Prefix);
      },
    validate_WorkflowNextStepID: function(sender) {
      var Prefix = sender.id.replace('WorkflowNextStepID','');
      this.validated_FK_xDMS_HFiles_WorkflowNextStepID_main = true;
      this.validate_FK_xDMS_HFiles_WorkflowNextStepID(sender,Prefix);
      },
    validate_UserID: function(sender) {
      var Prefix = sender.id.replace('UserID','');
      this.validated_FK_xDMS_HFiles_UserID_main = true;
      this.validate_FK_xDMS_HFiles_UserID(sender,Prefix);
      },
    validate_GroupID: function(sender) {
      var Prefix = sender.id.replace('GroupID','');
      this.validated_FK_xDMS_HFiles_GroupID_main = true;
      this.validate_FK_xDMS_HFiles_GroupID(sender,Prefix);
      },
    validate_FK_xDMS_HFiles_UserID: function(o,Prefix) {
      var value = o.id;
      var UserID = $get(Prefix + 'UserID');
      if(UserID.value==''){
        if(this.validated_FK_xDMS_HFiles_UserID_main){
          var o_d = $get(Prefix + 'UserID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_UserID(value, this.validated_FK_xDMS_HFiles_UserID);
      },
    validated_FK_xDMS_HFiles_UserID_main: false,
    validated_FK_xDMS_HFiles_UserID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_UserID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_StatusBy: function(o,Prefix) {
      var value = o.id;
      var StatusBy = $get(Prefix + 'StatusBy');
      if(StatusBy.value==''){
        if(this.validated_FK_xDMS_HFiles_StatusBy_main){
          var o_d = $get(Prefix + 'StatusBy' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + StatusBy.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_StatusBy(value, this.validated_FK_xDMS_HFiles_StatusBy);
      },
    validated_FK_xDMS_HFiles_StatusBy_main: false,
    validated_FK_xDMS_HFiles_StatusBy: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_StatusBy_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_FileTypeID: function(o,Prefix) {
      var value = o.id;
      var FileTypeID = $get(Prefix + 'FileTypeID');
      if(FileTypeID.value==''){
        if(this.validated_FK_xDMS_HFiles_FileTypeID_main){
          var o_d = $get(Prefix + 'FileTypeID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FileTypeID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_FileTypeID(value, this.validated_FK_xDMS_HFiles_FileTypeID);
      },
    validated_FK_xDMS_HFiles_FileTypeID_main: false,
    validated_FK_xDMS_HFiles_FileTypeID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_FileTypeID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_FolderID: function(o,Prefix) {
      var value = o.id;
      var FolderID = $get(Prefix + 'FolderID');
      if(FolderID.value==''){
        if(this.validated_FK_xDMS_HFiles_FolderID_main){
          var o_d = $get(Prefix + 'FolderID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FolderID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_FolderID(value, this.validated_FK_xDMS_HFiles_FolderID);
      },
    validated_FK_xDMS_HFiles_FolderID_main: false,
    validated_FK_xDMS_HFiles_FolderID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_FolderID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_GroupID: function(o,Prefix) {
      var value = o.id;
      var GroupID = $get(Prefix + 'GroupID');
      if(GroupID.value==''){
        if(this.validated_FK_xDMS_HFiles_GroupID_main){
          var o_d = $get(Prefix + 'GroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + GroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_GroupID(value, this.validated_FK_xDMS_HFiles_GroupID);
      },
    validated_FK_xDMS_HFiles_GroupID_main: false,
    validated_FK_xDMS_HFiles_GroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_GroupID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_ItemTypeID: function(o,Prefix) {
      var value = o.id;
      var ItemTypeID = $get(Prefix + 'ItemTypeID');
      if(ItemTypeID.value==''){
        if(this.validated_FK_xDMS_HFiles_ItemTypeID_main){
          var o_d = $get(Prefix + 'ItemTypeID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemTypeID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_ItemTypeID(value, this.validated_FK_xDMS_HFiles_ItemTypeID);
      },
    validated_FK_xDMS_HFiles_ItemTypeID_main: false,
    validated_FK_xDMS_HFiles_ItemTypeID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_ItemTypeID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_StatusID: function(o,Prefix) {
      var value = o.id;
      var StatusID = $get(Prefix + 'StatusID');
      if(StatusID.value==''){
        if(this.validated_FK_xDMS_HFiles_StatusID_main){
          var o_d = $get(Prefix + 'StatusID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + StatusID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_StatusID(value, this.validated_FK_xDMS_HFiles_StatusID);
      },
    validated_FK_xDMS_HFiles_StatusID_main: false,
    validated_FK_xDMS_HFiles_StatusID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_StatusID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_WorkflowID: function(o,Prefix) {
      var value = o.id;
      var WorkflowID = $get(Prefix + 'WorkflowID');
      if(WorkflowID.value==''){
        if(this.validated_FK_xDMS_HFiles_WorkflowID_main){
          var o_d = $get(Prefix + 'WorkflowID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + WorkflowID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_WorkflowID(value, this.validated_FK_xDMS_HFiles_WorkflowID);
      },
    validated_FK_xDMS_HFiles_WorkflowID_main: false,
    validated_FK_xDMS_HFiles_WorkflowID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_WorkflowID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_WorkflowNextStepID: function(o,Prefix) {
      var value = o.id;
      var WorkflowNextStepID = $get(Prefix + 'WorkflowNextStepID');
      if(WorkflowNextStepID.value==''){
        if(this.validated_FK_xDMS_HFiles_WorkflowNextStepID_main){
          var o_d = $get(Prefix + 'WorkflowNextStepID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + WorkflowNextStepID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_WorkflowNextStepID(value, this.validated_FK_xDMS_HFiles_WorkflowNextStepID);
      },
    validated_FK_xDMS_HFiles_WorkflowNextStepID_main: false,
    validated_FK_xDMS_HFiles_WorkflowNextStepID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_WorkflowNextStepID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_HFiles_WorkflowStepID: function(o,Prefix) {
      var value = o.id;
      var WorkflowStepID = $get(Prefix + 'WorkflowStepID');
      if(WorkflowStepID.value==''){
        if(this.validated_FK_xDMS_HFiles_WorkflowStepID_main){
          var o_d = $get(Prefix + 'WorkflowStepID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + WorkflowStepID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_HFiles_WorkflowStepID(value, this.validated_FK_xDMS_HFiles_WorkflowStepID);
      },
    validated_FK_xDMS_HFiles_WorkflowStepID_main: false,
    validated_FK_xDMS_HFiles_WorkflowStepID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsHFiles.validated_FK_xDMS_HFiles_WorkflowStepID_main){
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
