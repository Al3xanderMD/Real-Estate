﻿using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Lot : AuditableEntity
    {
        private Lot(Guid basePostId, double lotArea,double streetFrontage, Guid lotClassificationId)
        {
            Id = Guid.NewGuid();
            BasePostId = basePostId;
            LotArea = lotArea;
            StreetFrontage = streetFrontage;
            LotClassificationId = lotClassificationId;
        }

        private Lot(BasePost basePost, LotClassification lotClassification, Guid basePostId, double lotArea,double streetFrontage, Guid lotClassificationId) : this (basePostId, lotArea,streetFrontage, lotClassificationId)
        {
            BasePost = basePost;
            LotClassification = lotClassification;
        }

        public Guid Id { get; private set; }
        public Guid BasePostId { get; private set; } //attach
        public BasePost BasePost { get; private set; } = null!;
        public Guid LotClassificationId { get; private set; }
        public LotClassification LotClassification { get; private set; } = null!;
        public double LotArea { get; private set; }
        public double StreetFrontage { get; private set; }


        public static Result<Lot> Create(Guid basePostId, double lotArea, double streetFrontage, Guid lotClassificationId)
        {
            if (lotArea <= 0)
            {
                return Result<Lot>.Failure("Lot area must be larger than 0.");
            }

            if (streetFrontage <= 0) 
            {
                return Result<Lot>.Failure("Street frontage must be larger than 0.");
            }


            return Result<Lot>.Success(new Lot(basePostId, lotArea, streetFrontage, lotClassificationId));
        }

        public Result<BasePost> Delete()
        {
            throw new NotImplementedException();
        }

        public Result<BasePost> ReadPost()
        {
            throw new NotImplementedException();
        }

        public Result<BasePost> Update()
        {
            throw new NotImplementedException();
        }

        public void AttachBasePostId(Guid basePostId)
        {
           if (BasePostId != Guid.Empty)
           {
				BasePostId = basePostId;
		   }
		}

        public void AttachBasePost(BasePost basePost)
        {
			BasePost = basePost;
		}

        public void AttachLotClassificationId(Guid lotClassificationId)
        {
            if (LotClassificationId != Guid.Empty)
            {
                LotClassificationId = lotClassificationId;
            }
        }

        public void AttachLotClassification(LotClassification lotClassification)
        {
			LotClassification = lotClassification;
		}

        public void AttachLotArea(double lotArea)
        {
            LotArea = lotArea;
        }

        public void AttachStreetFrontage(double streetFrontage)
        {
			StreetFrontage = streetFrontage;
		}

    }
}
