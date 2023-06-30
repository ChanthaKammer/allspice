namespace allspice.Models;

public class Recipe{
   public int Id {get;set;}
   public string Title {get;set;}
   public string Instructions {get;set;}
   public string Img {get;set;}
   public string Category {get;set;}

   public bool Archived {get;set;}
   public string CreatorId {get;set;}
   public Account Creator {get;set;}
}


// type": "object",
//     "required": [
//         "id",
//         "title",
//         "instructions",
//         "img",
//         "category",
//         "creatorId"
//     ],
//     "properties": {
//         "id": {
//             "type": "number",
//         },
//         "creatorId": {
//             "type": "string"
//         },
//         "title": {
//             "type": "string"
//         },
//         "instructions": {
//             "type": "string"
//         },
//         "img": {
//             "type": "string"
//         },
//     },