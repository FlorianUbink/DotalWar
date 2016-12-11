using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotal_War.Collections
{
    public class ContentLoader
    {

        public ContentLoader(ContentManager content)
        {
            TextureDir.Unit0 = content.Load<Texture2D>(@"Placeholders\Unit0");
            TextureDir.Building0 = content.Load<Texture2D>(@"Placeholders\Building0");
            
        }
    }
}
