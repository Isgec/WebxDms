<script type="text/javascript"> 
var script_xDmsFileAuthorizations = {
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
    ACEFileID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FileID','');
      var F_FileID = $get(sender._element.id);
      var F_FileID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FileID.value = p[0];
      F_FileID_Display.innerHTML = e.get_text();
    },
    ACEFileID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FileID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFileID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACECreatedBy_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CreatedBy','');
      var F_CreatedBy = $get(sender._element.id);
      var F_CreatedBy_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CreatedBy.value = p[0];
      F_CreatedBy_Display.innerHTML = e.get_text();
    },
    ACECreatedBy_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CreatedBy','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECreatedBy_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CreatedBy: function(sender) {
      var Prefix = sender.id.replace('CreatedBy','');
      this.validated_FK_xDMS_FileAuthorizations_CreatedBy_main = true;
      this.validate_FK_xDMS_FileAuthorizations_CreatedBy(sender,Prefix);
      },
    validate_FK_xDMS_FileAuthorizations_CreatedBy: function(o,Prefix) {
      var value = o.id;
      var CreatedBy = $get(Prefix + 'CreatedBy');
      if(CreatedBy.value==''){
        if(this.validated_FK_xDMS_FileAuthorizations_CreatedBy_main){
          var o_d = $get(Prefix + 'CreatedBy' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CreatedBy.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_FileAuthorizations_CreatedBy(value, this.validated_FK_xDMS_FileAuthorizations_CreatedBy);
      },
    validated_FK_xDMS_FileAuthorizations_CreatedBy_main: false,
    validated_FK_xDMS_FileAuthorizations_CreatedBy: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_xDmsFileAuthorizations.validated_FK_xDMS_FileAuthorizations_CreatedBy_main){
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
