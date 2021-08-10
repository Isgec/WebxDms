<script type="text/javascript"> 
var script_xDmsFiles = {
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
      var retval = e.get_value();
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
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEParentIFileID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ParentIFileID','');
      var F_ParentIFileID = $get(sender._element.id);
      var F_ParentIFileID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ParentIFileID.value = p[0];
      F_ParentIFileID_Display.innerHTML = e.get_text();
    },
    ACEParentIFileID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ParentIFileID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEParentIFileID_Populated: function(sender,e) {
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
    validate_FileTypeID: function(sender) {
      var Prefix = sender.id.replace('FileTypeID','');
      this.validated_FK_xDMS_Files_FileTypeID_main = true;
      this.validate_FK_xDMS_Files_FileTypeID(sender,Prefix);
      },
    validate_FolderID: function(sender) {
      var Prefix = sender.id.replace('FolderID','');
      this.validated_FK_xDMS_Files_FolderID_main = true;
      this.validate_FK_xDMS_Files_FolderID(sender,Prefix);
      },
    validate_StatusID: function(sender) {
      var Prefix = sender.id.replace('StatusID','');
      this.validated_FK_xDMS_Files_StatusID_main = true;
      this.validate_FK_xDMS_Files_StatusID(sender,Prefix);
      },
    validate_ParentIFileID: function(sender) {
      var Prefix = sender.id.replace('ParentIFileID','');
      this.validated_FK_xDMS_Files_ParentFileID_main = true;
      this.validate_FK_xDMS_Files_ParentFileID(sender,Prefix);
      },
    validate_StatusBy: function(sender) {
      var Prefix = sender.id.replace('StatusBy','');
      this.validated_FK_xDMS_Files_StatusBy_main = true;
      this.validate_FK_xDMS_Files_StatusBy(sender,Prefix);
      },
    validate_FK_xDMS_Files_StatusBy: function(o,Prefix) {
      var value = o.id;
      var StatusBy = $get(Prefix + 'StatusBy');
      if(StatusBy.value==''){
        if(this.validated_FK_xDMS_Files_StatusBy_main){
          var o_d = $get(Prefix + 'StatusBy' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + StatusBy.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Files_StatusBy(value, this.validated_FK_xDMS_Files_StatusBy);
      },
    validated_FK_xDMS_Files_StatusBy_main: false,
    validated_FK_xDMS_Files_StatusBy: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFiles.validated_FK_xDMS_Files_StatusBy_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Files_ParentFileID: function(o,Prefix) {
      var value = o.id;
      var ParentIFileID = $get(Prefix + 'ParentIFileID');
      if(ParentIFileID.value==''){
        if(this.validated_FK_xDMS_Files_ParentFileID_main){
          var o_d = $get(Prefix + 'ParentIFileID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ParentIFileID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Files_ParentFileID(value, this.validated_FK_xDMS_Files_ParentFileID);
      },
    validated_FK_xDMS_Files_ParentFileID_main: false,
    validated_FK_xDMS_Files_ParentFileID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFiles.validated_FK_xDMS_Files_ParentFileID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Files_FolderID: function(o,Prefix) {
      var value = o.id;
      var FolderID = $get(Prefix + 'FolderID');
      if(FolderID.value==''){
        if(this.validated_FK_xDMS_Files_FolderID_main){
          var o_d = $get(Prefix + 'FolderID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FolderID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Files_FolderID(value, this.validated_FK_xDMS_Files_FolderID);
      },
    validated_FK_xDMS_Files_FolderID_main: false,
    validated_FK_xDMS_Files_FolderID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFiles.validated_FK_xDMS_Files_FolderID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_Files_StatusID: function(o,Prefix) {
      var value = o.id;
      var StatusID = $get(Prefix + 'StatusID');
      if(StatusID.value==''){
        if(this.validated_FK_xDMS_Files_StatusID_main){
          var o_d = $get(Prefix + 'StatusID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + StatusID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Files_StatusID(value, this.validated_FK_xDMS_Files_StatusID);
      },
    validated_FK_xDMS_Files_StatusID_main: false,
    validated_FK_xDMS_Files_StatusID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFiles.validated_FK_xDMS_Files_StatusID_main){
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
