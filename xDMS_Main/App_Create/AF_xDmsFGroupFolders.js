<script type="text/javascript"> 
var script_xDmsFGroupFolders = {
    ACEFGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FGroupID','');
      var F_FGroupID = $get(sender._element.id);
      var F_FGroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FGroupID.value = p[0];
      F_FGroupID_Display.innerHTML = e.get_text();
    },
    ACEFGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FGroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFGroupID_Populated: function(sender,e) {
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
    validate_FGroupID: function(sender) {
      var Prefix = sender.id.replace('FGroupID','');
      this.validated_FK_xDMS_FGroupFolders_FGroupID_main = true;
      this.validate_FK_xDMS_FGroupFolders_FGroupID(sender,Prefix);
      },
    validate_FolderID: function(sender) {
      var Prefix = sender.id.replace('FolderID','');
      this.validated_FK_xDMS_FGroupFolders_FolderID_main = true;
      this.validate_FK_xDMS_FGroupFolders_FolderID(sender,Prefix);
      },
    validate_FK_xDMS_FGroupFolders_FGroupID: function(o,Prefix) {
      var value = o.id;
      var FGroupID = $get(Prefix + 'FGroupID');
      if(FGroupID.value==''){
        if(this.validated_FK_xDMS_FGroupFolders_FGroupID_main){
          var o_d = $get(Prefix + 'FGroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FGroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FGroupFolders_FGroupID(value, this.validated_FK_xDMS_FGroupFolders_FGroupID);
      },
    validated_FK_xDMS_FGroupFolders_FGroupID_main: false,
    validated_FK_xDMS_FGroupFolders_FGroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFGroupFolders.validated_FK_xDMS_FGroupFolders_FGroupID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_xDMS_FGroupFolders_FolderID: function(o,Prefix) {
      var value = o.id;
      var FolderID = $get(Prefix + 'FolderID');
      if(FolderID.value==''){
        if(this.validated_FK_xDMS_FGroupFolders_FolderID_main){
          var o_d = $get(Prefix + 'FolderID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FolderID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FGroupFolders_FolderID(value, this.validated_FK_xDMS_FGroupFolders_FolderID);
      },
    validated_FK_xDMS_FGroupFolders_FolderID_main: false,
    validated_FK_xDMS_FGroupFolders_FolderID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFGroupFolders.validated_FK_xDMS_FGroupFolders_FolderID_main){
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
