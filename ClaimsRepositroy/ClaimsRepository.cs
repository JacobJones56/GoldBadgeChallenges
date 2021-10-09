using ClaimsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepositroy
{
    public class ClaimsRepository
    {
        private Queue<Claim> _queueOfClaims = new Queue<Claim>();
        private int _claimsIdCounter = default;
        // Create 
        public bool CreateNewClaim(Claim claim)
        {
            if(claim is null)
            {
                return false;
            }
            claim.ClaimID = ++_claimsIdCounter;
            _queueOfClaims.Enqueue(claim);
            return true;
        }

        // Read

        public Queue<Claim> ClaimList()
        {
            return _queueOfClaims;
        }

        // Delete
        public void RemoveClaim(Claim claim)
        {
            _queueOfClaims.Dequeue();
        }


        public Claim PeekClaim()
        {
            return _queueOfClaims.Peek();
        }



    }
}
