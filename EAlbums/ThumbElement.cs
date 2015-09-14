using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace EAlbums
{
   public class ThumbElement
   {
       public virtual string Name { get; set; }
       public virtual string FullPath { get; set; }
       public virtual string Description { get; set; }
       public virtual ThumbImage ThumbImage { get; set; }
   }
}
