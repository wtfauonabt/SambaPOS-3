using System.Collections.ObjectModel;
using System.Linq;
using Samba.Domain.Models.Tickets;
using Samba.Presentation.Common;

namespace Samba.Modules.PaymentModule
{
    public class OrderSelectorViewModel : ObservableObject
    {
        public OrderSelectorViewModel(OrderSelector model)
        {
            Model = model;
            Selectors = new ObservableCollection<SelectorViewModel>();
        }

        protected OrderSelector Model { get; set; }
        public ObservableCollection<SelectorViewModel> Selectors { get; set; }

        public decimal SelectedTotal { get { return Model.SelectedTotal; } }
        public decimal RemainingTotal { get { return Model.RemainingTotal; } }

        public void UpdateTicket(Ticket ticket)
        {
            Model.UpdateTicket(ticket);
            Selectors.Clear();
            Selectors.AddRange(Model.Selectors.Select(x => new SelectorViewModel(x)));
            Refresh();
        }

        public void PersistSelectedItems()
        {
            Model.PersistSelectedItems();
            Refresh();
        }

        public void PersistTicket()
        {
            Model.PersistTicket();
            Refresh();
        }

        public void ClearSelection()
        {
            Model.ClearSelection();
            Refresh();
        }

        public void UpdateExchangeRate(decimal exchangeRate)
        {
            Model.UpdateExchangeRate(exchangeRate);
            Refresh();
        }

        private void Refresh()
        {
            Selectors.ToList().ForEach(x => x.Refresh());
        }

        public void UpdateAutoRoundValue(decimal autoRoundDiscount)
        {
            Model.UpdateAutoRoundValue(autoRoundDiscount);
        }
    }
}