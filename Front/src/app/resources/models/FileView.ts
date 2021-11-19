export class FileView {
  Id: String;
  FileName : String;
  Path : String;
  Title : String;
  Subtitle : String;
  Author : String;
  PublishDate : String;
    
  constructor(id: String,fileName : String,path : String,title : String,subtitle : String,author : String,publishDate : String) {
    this.Id = id;
    this.FileName = fileName;
    this.Title = title;
    this.Path = path;
    this.Subtitle = subtitle;
    this.Author = author;
    this.PublishDate = publishDate;
  }
}