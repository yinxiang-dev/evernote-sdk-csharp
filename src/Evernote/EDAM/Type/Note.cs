/**
 * Autogenerated by Thrift Compiler (1.0.0-dev)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Evernote.EDAM.Type
{

  /// <summary>
  /// Represents a single note in the user's account.
  /// 
  /// <dl>
  /// <dt>guid</dt>
  ///   <dd>The unique identifier of this note.  Will be set by the
  ///   server, but will be omitted by clients calling NoteStore.createNote()
  ///   <br/>
  ///   Length:  EDAM_GUID_LEN_MIN - EDAM_GUID_LEN_MAX
  ///   <br/>
  ///   Regex:  EDAM_GUID_REGEX
  ///   </dd>
  /// 
  /// <dt>title</dt>
  ///   <dd>The subject of the note.  Can't begin or end with a space.
  ///   <br/>
  ///   Length:  EDAM_NOTE_TITLE_LEN_MIN - EDAM_NOTE_TITLE_LEN_MAX
  ///   <br/>
  ///   Regex:  EDAM_NOTE_TITLE_REGEX
  ///   </dd>
  /// 
  /// <dt>content</dt>
  ///   <dd>The XHTML block that makes up the note.  This is
  ///   the canonical form of the note's contents, so will include abstract
  ///   Evernote tags for internal resource references.  A client may create
  ///   a separate transformed version of this content for internal presentation,
  ///   but the same canonical bytes should be used for transmission and
  ///   comparison unless the user chooses to modify their content.
  ///   <br/>
  ///   Length:  EDAM_NOTE_CONTENT_LEN_MIN - EDAM_NOTE_CONTENT_LEN_MAX
  ///   </dd>
  /// 
  /// <dt>contentHash</dt>
  ///   <dd>The binary MD5 checksum of the UTF-8 encoded content
  ///   body. This will always be set by the server, but clients may choose to omit
  ///   this when they submit a note with content.
  ///   <br/>
  ///   Length:  EDAM_HASH_LEN (exactly)
  ///   </dd>
  /// 
  /// <dt>contentLength</dt>
  ///   <dd>The number of Unicode characters in the content of
  ///   the note.  This will always be set by the service, but clients may choose
  ///   to omit this value when they submit a Note.
  ///   </dd>
  /// 
  /// <dt>created</dt>
  ///   <dd>The date and time when the note was created in one of the
  ///   clients.  In most cases, this will match the user's sense of when
  ///   the note was created, and ordering between notes will be based on
  ///   ordering of this field.  However, this is not a "reliable" timestamp
  ///   if a client has an incorrect clock, so it cannot provide a true absolute
  ///   ordering between notes.  Notes created directly through the service
  ///   (e.g. via the web GUI) will have an absolutely ordered "created" value.
  ///   </dd>
  /// 
  /// <dt>updated</dt>
  ///   <dd>The date and time when the note was last modified in one of
  ///   the clients.  In most cases, this will match the user's sense of when
  ///   the note was modified, but this field may not be absolutely reliable
  ///   due to the possibility of client clock errors.
  ///   </dd>
  /// 
  /// <dt>deleted</dt>
  ///   <dd>If present, the note is considered "deleted", and this
  ///   stores the date and time when the note was deleted by one of the clients.
  ///   In most cases, this will match the user's sense of when the note was
  ///   deleted, but this field may be unreliable due to the possibility of
  ///   client clock errors.
  ///   </dd>
  /// 
  /// <dt>active</dt>
  ///   <dd>If the note is available for normal actions and viewing,
  ///   this flag will be set to true.
  ///   </dd>
  /// 
  /// <dt>updateSequenceNum</dt>
  ///   <dd>A number identifying the last transaction to
  ///   modify the state of this note (including changes to the note's attributes
  ///   or resources).  The USN values are sequential within an account,
  ///   and can be used to compare the order of modifications within the service.
  ///   </dd>
  /// 
  /// <dt>notebookGuid</dt>
  ///   <dd>The unique identifier of the notebook that contains
  ///   this note.  If no notebookGuid is provided on a call to createNote(), the
  ///   default notebook will be used instead.
  ///   <br/>
  ///   Length:  EDAM_GUID_LEN_MIN - EDAM_GUID_LEN_MAX
  ///   <br/>
  ///   Regex:  EDAM_GUID_REGEX
  ///   </dd>
  /// 
  /// <dt>tagGuids</dt>
  ///   <dd>A list of the GUID identifiers for tags that are applied to this note.
  ///   This may be provided in a call to createNote() to unambiguously declare
  ///   the tags that should be assigned to the new note.  Alternately, clients
  ///   may pass the names of desired tags via the 'tagNames' field during
  ///   note creation.
  ///   If the list of tags are omitted on a call to createNote(), then
  ///   the server will assume that no changes have been made to the resources.
  ///   Maximum:  EDAM_NOTE_TAGS_MAX tags per note
  ///   </dd>
  /// 
  /// <dt>resources</dt>
  ///   <dd>The list of resources that are embedded within this note.
  ///   If the list of resources are omitted on a call to updateNote(), then
  ///   the server will assume that no changes have been made to the resources.
  ///   The binary contents of the resources must be provided when the resource
  ///   is first sent to the service, but it will be omitted by the service when
  ///   the Note is returned in the future.
  ///   Maximum:  EDAM_NOTE_RESOURCES_MAX resources per note
  ///   </dd>
  /// 
  /// <dt>attributes</dt>
  ///   <dd>A list of the attributes for this note.
  ///   If the list of attributes are omitted on a call to updateNote(), then
  ///   the server will assume that no changes have been made to the resources.
  ///   </dd>
  /// 
  /// <dt>tagNames</dt>
  ///   <dd>May be provided by clients during calls to createNote() as an
  ///   alternative to providing the tagGuids of existing tags.  If any tagNames
  ///   are provided during createNote(), these will be found, or created if they
  ///   don't already exist.  Created tags will have no parent (they will be at
  ///   the top level of the tag panel).
  ///   </dd>
  /// 
  /// <dt>sharedNotes</dt>
  ///   <dd>The list of recipients with whom this note has been shared. This field will be unset if
  ///     the caller has access to the note via the containing notebook, but does not have activity
  ///     feed permission for that notebook. This field is read-only. Clients may not make changes to
  ///     a note's sharing state via this field.
  ///   </dd>
  /// 
  ///   <dt>restrictions</dt>
  ///   <dd>If this field is set, the user has note-level permissions that may differ from their
  ///     notebook-level permissions. In this case, the restrictions structure specifies
  ///     a set of restrictions limiting the actions that a user may take on the note based
  ///     on their note-level permissions. If this field is unset, then there are no
  ///     note-specific restrictions. However, a client may still be limited based on the user's
  ///     notebook permissions.</dd>
  /// </dl>
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Note : TBase
  {
    private string _guid;
    private string _title;
    private string _content;
    private byte[] _contentHash;
    private int _contentLength;
    private long _created;
    private long _updated;
    private long _deleted;
    private bool _active;
    private int _updateSequenceNum;
    private string _notebookGuid;
    private List<string> _tagGuids;
    private List<Resource> _resources;
    private NoteAttributes _attributes;
    private List<string> _tagNames;
    private List<SharedNote> _sharedNotes;
    private NoteRestrictions _restrictions;
    private NoteLimits _limits;

    public string Guid
    {
      get
      {
        return _guid;
      }
      set
      {
        __isset.guid = true;
        this._guid = value;
      }
    }

    public string Title
    {
      get
      {
        return _title;
      }
      set
      {
        __isset.title = true;
        this._title = value;
      }
    }

    public string Content
    {
      get
      {
        return _content;
      }
      set
      {
        __isset.content = true;
        this._content = value;
      }
    }

    public byte[] ContentHash
    {
      get
      {
        return _contentHash;
      }
      set
      {
        __isset.contentHash = true;
        this._contentHash = value;
      }
    }

    public int ContentLength
    {
      get
      {
        return _contentLength;
      }
      set
      {
        __isset.contentLength = true;
        this._contentLength = value;
      }
    }

    public long Created
    {
      get
      {
        return _created;
      }
      set
      {
        __isset.created = true;
        this._created = value;
      }
    }

    public long Updated
    {
      get
      {
        return _updated;
      }
      set
      {
        __isset.updated = true;
        this._updated = value;
      }
    }

    public long Deleted
    {
      get
      {
        return _deleted;
      }
      set
      {
        __isset.deleted = true;
        this._deleted = value;
      }
    }

    public bool Active
    {
      get
      {
        return _active;
      }
      set
      {
        __isset.active = true;
        this._active = value;
      }
    }

    public int UpdateSequenceNum
    {
      get
      {
        return _updateSequenceNum;
      }
      set
      {
        __isset.updateSequenceNum = true;
        this._updateSequenceNum = value;
      }
    }

    public string NotebookGuid
    {
      get
      {
        return _notebookGuid;
      }
      set
      {
        __isset.notebookGuid = true;
        this._notebookGuid = value;
      }
    }

    public List<string> TagGuids
    {
      get
      {
        return _tagGuids;
      }
      set
      {
        __isset.tagGuids = true;
        this._tagGuids = value;
      }
    }

    public List<Resource> Resources
    {
      get
      {
        return _resources;
      }
      set
      {
        __isset.resources = true;
        this._resources = value;
      }
    }

    public NoteAttributes Attributes
    {
      get
      {
        return _attributes;
      }
      set
      {
        __isset.attributes = true;
        this._attributes = value;
      }
    }

    public List<string> TagNames
    {
      get
      {
        return _tagNames;
      }
      set
      {
        __isset.tagNames = true;
        this._tagNames = value;
      }
    }

    public List<SharedNote> SharedNotes
    {
      get
      {
        return _sharedNotes;
      }
      set
      {
        __isset.sharedNotes = true;
        this._sharedNotes = value;
      }
    }

    public NoteRestrictions Restrictions
    {
      get
      {
        return _restrictions;
      }
      set
      {
        __isset.restrictions = true;
        this._restrictions = value;
      }
    }

    public NoteLimits Limits
    {
      get
      {
        return _limits;
      }
      set
      {
        __isset.limits = true;
        this._limits = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool guid;
      public bool title;
      public bool content;
      public bool contentHash;
      public bool contentLength;
      public bool created;
      public bool updated;
      public bool deleted;
      public bool active;
      public bool updateSequenceNum;
      public bool notebookGuid;
      public bool tagGuids;
      public bool resources;
      public bool attributes;
      public bool tagNames;
      public bool sharedNotes;
      public bool restrictions;
      public bool limits;
    }

    public Note() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Guid = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Title = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Content = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                ContentHash = iprot.ReadBinary();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I32) {
                ContentLength = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.I64) {
                Created = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.I64) {
                Updated = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.I64) {
                Deleted = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.Bool) {
                Active = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.I32) {
                UpdateSequenceNum = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.String) {
                NotebookGuid = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 12:
              if (field.Type == TType.List) {
                {
                  TagGuids = new List<string>();
                  TList _list22 = iprot.ReadListBegin();
                  for( int _i23 = 0; _i23 < _list22.Count; ++_i23)
                  {
                    string _elem24;
                    _elem24 = iprot.ReadString();
                    TagGuids.Add(_elem24);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 13:
              if (field.Type == TType.List) {
                {
                  Resources = new List<Resource>();
                  TList _list25 = iprot.ReadListBegin();
                  for( int _i26 = 0; _i26 < _list25.Count; ++_i26)
                  {
                    Resource _elem27;
                    _elem27 = new Resource();
                    _elem27.Read(iprot);
                    Resources.Add(_elem27);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 14:
              if (field.Type == TType.Struct) {
                Attributes = new NoteAttributes();
                Attributes.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 15:
              if (field.Type == TType.List) {
                {
                  TagNames = new List<string>();
                  TList _list28 = iprot.ReadListBegin();
                  for( int _i29 = 0; _i29 < _list28.Count; ++_i29)
                  {
                    string _elem30;
                    _elem30 = iprot.ReadString();
                    TagNames.Add(_elem30);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 16:
              if (field.Type == TType.List) {
                {
                  SharedNotes = new List<SharedNote>();
                  TList _list31 = iprot.ReadListBegin();
                  for( int _i32 = 0; _i32 < _list31.Count; ++_i32)
                  {
                    SharedNote _elem33;
                    _elem33 = new SharedNote();
                    _elem33.Read(iprot);
                    SharedNotes.Add(_elem33);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 17:
              if (field.Type == TType.Struct) {
                Restrictions = new NoteRestrictions();
                Restrictions.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 18:
              if (field.Type == TType.Struct) {
                Limits = new NoteLimits();
                Limits.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("Note");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Guid != null && __isset.guid) {
          field.Name = "guid";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Guid);
          oprot.WriteFieldEnd();
        }
        if (Title != null && __isset.title) {
          field.Name = "title";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Title);
          oprot.WriteFieldEnd();
        }
        if (Content != null && __isset.content) {
          field.Name = "content";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Content);
          oprot.WriteFieldEnd();
        }
        if (ContentHash != null && __isset.contentHash) {
          field.Name = "contentHash";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteBinary(ContentHash);
          oprot.WriteFieldEnd();
        }
        if (__isset.contentLength) {
          field.Name = "contentLength";
          field.Type = TType.I32;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(ContentLength);
          oprot.WriteFieldEnd();
        }
        if (__isset.created) {
          field.Name = "created";
          field.Type = TType.I64;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Created);
          oprot.WriteFieldEnd();
        }
        if (__isset.updated) {
          field.Name = "updated";
          field.Type = TType.I64;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Updated);
          oprot.WriteFieldEnd();
        }
        if (__isset.deleted) {
          field.Name = "deleted";
          field.Type = TType.I64;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Deleted);
          oprot.WriteFieldEnd();
        }
        if (__isset.active) {
          field.Name = "active";
          field.Type = TType.Bool;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Active);
          oprot.WriteFieldEnd();
        }
        if (__isset.updateSequenceNum) {
          field.Name = "updateSequenceNum";
          field.Type = TType.I32;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(UpdateSequenceNum);
          oprot.WriteFieldEnd();
        }
        if (NotebookGuid != null && __isset.notebookGuid) {
          field.Name = "notebookGuid";
          field.Type = TType.String;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(NotebookGuid);
          oprot.WriteFieldEnd();
        }
        if (TagGuids != null && __isset.tagGuids) {
          field.Name = "tagGuids";
          field.Type = TType.List;
          field.ID = 12;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, TagGuids.Count));
            foreach (string _iter34 in TagGuids)
            {
              oprot.WriteString(_iter34);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Resources != null && __isset.resources) {
          field.Name = "resources";
          field.Type = TType.List;
          field.ID = 13;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Resources.Count));
            foreach (Resource _iter35 in Resources)
            {
              _iter35.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Attributes != null && __isset.attributes) {
          field.Name = "attributes";
          field.Type = TType.Struct;
          field.ID = 14;
          oprot.WriteFieldBegin(field);
          Attributes.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (TagNames != null && __isset.tagNames) {
          field.Name = "tagNames";
          field.Type = TType.List;
          field.ID = 15;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, TagNames.Count));
            foreach (string _iter36 in TagNames)
            {
              oprot.WriteString(_iter36);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (SharedNotes != null && __isset.sharedNotes) {
          field.Name = "sharedNotes";
          field.Type = TType.List;
          field.ID = 16;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, SharedNotes.Count));
            foreach (SharedNote _iter37 in SharedNotes)
            {
              _iter37.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Restrictions != null && __isset.restrictions) {
          field.Name = "restrictions";
          field.Type = TType.Struct;
          field.ID = 17;
          oprot.WriteFieldBegin(field);
          Restrictions.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Limits != null && __isset.limits) {
          field.Name = "limits";
          field.Type = TType.Struct;
          field.ID = 18;
          oprot.WriteFieldBegin(field);
          Limits.Write(oprot);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Note(");
      bool __first = true;
      if (Guid != null && __isset.guid) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Guid: ");
        __sb.Append(Guid);
      }
      if (Title != null && __isset.title) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Title: ");
        __sb.Append(Title);
      }
      if (Content != null && __isset.content) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Content: ");
        __sb.Append(Content);
      }
      if (ContentHash != null && __isset.contentHash) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ContentHash: ");
        __sb.Append(ContentHash);
      }
      if (__isset.contentLength) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ContentLength: ");
        __sb.Append(ContentLength);
      }
      if (__isset.created) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Created: ");
        __sb.Append(Created);
      }
      if (__isset.updated) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Updated: ");
        __sb.Append(Updated);
      }
      if (__isset.deleted) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Deleted: ");
        __sb.Append(Deleted);
      }
      if (__isset.active) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Active: ");
        __sb.Append(Active);
      }
      if (__isset.updateSequenceNum) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("UpdateSequenceNum: ");
        __sb.Append(UpdateSequenceNum);
      }
      if (NotebookGuid != null && __isset.notebookGuid) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NotebookGuid: ");
        __sb.Append(NotebookGuid);
      }
      if (TagGuids != null && __isset.tagGuids) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TagGuids: ");
        __sb.Append(TagGuids);
      }
      if (Resources != null && __isset.resources) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Resources: ");
        __sb.Append(Resources);
      }
      if (Attributes != null && __isset.attributes) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Attributes: ");
        __sb.Append(Attributes== null ? "<null>" : Attributes.ToString());
      }
      if (TagNames != null && __isset.tagNames) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TagNames: ");
        __sb.Append(TagNames);
      }
      if (SharedNotes != null && __isset.sharedNotes) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SharedNotes: ");
        __sb.Append(SharedNotes);
      }
      if (Restrictions != null && __isset.restrictions) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Restrictions: ");
        __sb.Append(Restrictions== null ? "<null>" : Restrictions.ToString());
      }
      if (Limits != null && __isset.limits) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Limits: ");
        __sb.Append(Limits== null ? "<null>" : Limits.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
