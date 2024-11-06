﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatorisCityAppNew.Viewmodels
{
    internal class ImageViewModel
    {
        public int ImageId { get; set; } = 0;
        public string FilePath { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NamePart { get; set; } = string.Empty;
        public Int32 NumberPart { get; set; } = 0;
        public int SequenceNumber { get; set; } = 0;
        public string TrailingPart { get; set; } = string.Empty;
        public ImageEnum ImageRole { get; set; }
        public ImageDetailEntity GetEntity()
        {
            ImageDetailEntity entity = new ImageDetailEntity();
            entity.ImageId = ImageId;
            entity.FilePath = FilePath;
            entity.Name = Name;
            entity.NamePart = NamePart;
            entity.NumberPart = NumberPart;
            entity.SequenceNumber = SequenceNumber;
            entity.TrailingPart = TrailingPart;
            entity.ImageRole = ImageRole;
            return entity;
        }
        public void ToModel(ImageDetailEntity entity)
        {
            ImageId = entity.ImageId;
            FilePath = entity.FilePath;
            Name = entity.Name;
            NamePart = entity.NamePart;
            NumberPart  = entity.NumberPart;
            SequenceNumber = entity.SequenceNumber;
            TrailingPart = entity.TrailingPart;
            ImageRole = entity.ImageRole;
        }

    }
}
