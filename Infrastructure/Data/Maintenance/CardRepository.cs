using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data.Maintenance
{
    public class CardRepository : ICardRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public CardRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }


        public void AddAuthCard(AuthorizationCard card)
        {
            try
            {
                _db.AuthorizationCards.Add(card);
                _db.SaveChanges();
                MessageBox.Show("Successfully added authorization card", "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void AddSpecialCard(SpecialCard card)
        {
            try
            {
                _db.SpecialCards.Add(card);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
            }
        }

        public void AddGuestCard(GuestCard card)
        {
            try
            {
                _db.GuestCards.Add(card);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
            }
        }

        public List<SpecialCardViewModel> GetAllSpecialCards()
        {
            try
            {
                var allSpecialCards = from card in _db.SpecialCards.Where(c => c.IsTrashed == false).OrderBy(c => c.DateCreated)
                                      select new SpecialCardViewModel
                                      {
                                          Id = card.Id,
                                          CardNo = card.CardNo,
                                          CardType = card.CardType,
                                          IssueTime = card.IssueTime,
                                          RefundTime = card.RefundTime,
                                          IssuedBy = card.ApplicationUser.FullName,
                                          CanOpenDeadLocks = card.CanOpenDeadLocks,
                                          PassageMode = card.PassageMode,
                                          DateCreated = card.DateCreated,
                                          DateModified = card.DateModified,
                                      };
                return allSpecialCards.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public AuthorizationCard GetAuthCardByComputer(string computerName)
        {
            try
            {
                return _db.AuthorizationCards.FirstOrDefault(aC => aC.ComputerName == computerName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public AuthorizationCard GetAuthCardById(string id)
        {
            try
            {
                return _db.AuthorizationCards.FirstOrDefault(aC => aC.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public GuestCard GetGuestCardBybookingId(string id)
        {
            try
            {
                return _db.GuestCards.FirstOrDefault(gC => gC.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public SpecialCard GetCardByNo(string cardNo)
        {
            try
            {
                return _db.SpecialCards.FirstOrDefault(c => c.CardNo == cardNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteCard(string Id)
        {
            try
            {
                var card = _db.SpecialCards.FirstOrDefault(c => c.Id == Id);
                if (card != null)
                {
                    card.IsTrashed = true;
                    _db.Entry(card).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void DeleteGuestCard(string Id)
        {
            try
            {
                var card = _db.GuestCards.FirstOrDefault(c => c.Id == Id);
                if (card != null)
                {
                    card.IsTrashed = true;
                    _db.Entry(card).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

    }
}
