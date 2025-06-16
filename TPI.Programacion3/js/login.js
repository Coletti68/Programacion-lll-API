$(document).ready(function() {
      // Vehicles data
      const vehicles = [
        { id: 1, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Blanco.jpg' },
        { id: 2, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Negro.jpg' },
        { id: 3, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Rojo.jpg' },
        { id: 4, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Gris.jpg' },
        { id: 5, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Rojo.jpg' },
        { id: 6, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Gris2.jpg' },
        { id: 7, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Blanco.jpg' },
        { id: 8, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Gris.jpg' },
        { id: 9, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Gris2.jpg' },
        { id: 10, model: 'Fiat Cronos', pricePerDay: 15000, image: '../images/Negro.jpg' }
      ];
      
      // Navigation
      function showSection(sectionId) {
        $('#home-section, #fleet-section, #login-section, #register-section').addClass('hide');
        $(sectionId).removeClass('hide');
      }
      
      $('#home-link').click(function() {
        showSection('#home-section');
      });
      
      $('#fleet-link').click(function() {
        showSection('#fleet-section');
        populateVehicles();
      });
      
      $('#login-link').click(function() {
        showSection('#login-section');
      });
      
      $('#register-link').click(function() {
        showSection('#register-section');
      });
      
      $('#view-fleet-btn').click(function() {
        showSection('#fleet-section');
        populateVehicles();
      });
      
      // Populate vehicles
      function populateVehicles() {
        const container = $('#vehicle-container');
        container.empty();
        
        vehicles.forEach(vehicle => {
          const card = `
            <div class="col-md-4 col-sm-6">
              <div class="card vehicle-card">
                <img src="${vehicle.image}" class="card-img-top vehicle-img" alt="${vehicle.model}">
                <div class="card-body">
                  <h5 class="card-title">${vehicle.model}</h5>
                  <p class="card-text">ARS ${vehicle.pricePerDay} por dia</p>
                  <button class="btn rent-btn" data-vehicle-id="${vehicle.id}">Alquilar ahora</button>
                </div>
              </div>
            </div>
          `;
          
          container.append(card);
        });
        
        // Add event listeners to rent buttons
        $('.rent-btn').click(function() {
          const vehicleId = $(this).data('vehicle-id');
          openReservationModal(vehicleId);
        });
      }
      
      // User authentication
      let currentUser = null;
      
      // Check if user is already logged in
      function checkLoggedInUser() {
        const userData = localStorage.getItem('currentUser');
        if (userData) {
          currentUser = JSON.parse(userData);
          updateNavForLoggedInUser();
        }
      }
      
      function updateNavForLoggedInUser() {
        if (currentUser) {
          $('#login-link, #register-link').parent().addClass('d-none');
          $('#user-info, #logout-item').removeClass('d-none');
          $('#user-name').text(currentUser.firstName);
        } else {
          $('#login-link, #register-link').parent().removeClass('d-none');
          $('#user-info, #logout-item').addClass('d-none');
        }
      }
      
      // Register form submission
      $('#register-form').submit(function(e) {
        e.preventDefault();
        
        const firstName = $('#register-firstname').val();
        const lastName = $('#register-lastname').val();
        const email = $('#register-email').val();
        const password = $('#register-password').val();
        
        // Save user to localStorage
        const newUser = {
          firstName,
          lastName,
          email,
          password
        };
        
        // Get existing users or create new array
        let users = JSON.parse(localStorage.getItem('users')) || [];
        users.push(newUser);
        localStorage.setItem('users', JSON.stringify(users));
        
        // Set as current user
        currentUser = newUser;
        localStorage.setItem('currentUser', JSON.stringify(currentUser));
        
        // Update UI
        updateNavForLoggedInUser();
        
        // Redirect to fleet
        showSection('#fleet-section');
        populateVehicles();
        
        // Reset form
        $('#register-form')[0].reset();
      });
      
      // Login form submission
      $('#login-form').submit(function(e) {
        e.preventDefault();
        
        const email = $('#login-email').val();
        const password = $('#login-password').val();
        
        // Get users from localStorage
        const users = JSON.parse(localStorage.getItem('users')) || [];
        
        // Find user
        const user = users.find(u => u.email === email && u.password === password);
        
        if (user) {
          // Set as current user
          currentUser = user;
          localStorage.setItem('currentUser', JSON.stringify(currentUser));
          
          // Update UI
          updateNavForLoggedInUser();
          
          // Redirect to fleet
          showSection('#fleet-section');
          populateVehicles();
          
          // Reset form
          $('#login-form')[0].reset();
        } else {
          alert('Invalid email or password');
        }
      });
      
      // Logout
      $('#logout-link').click(function() {
        // Clear current user
        currentUser = null;
        localStorage.removeItem('currentUser');
        
        // Update UI
        updateNavForLoggedInUser();
        
        // Redirect to home
        showSection('#home-section');
      });
      
      // Reservation modal
      let selectedVehicle = null;
      
      function openReservationModal(vehicleId) {
        // Check if user is logged in
        if (!currentUser) {
          alert('Por favor registrate para realizar la reserva.');
          showSection('#login-section');
          return;
        }
        
        // Find vehicle
        selectedVehicle = vehicles.find(v => v.id === vehicleId);
        
        // Set user details
        $('#fullname').val(`${currentUser.firstName} ${currentUser.lastName}`);
        
        // Reset other fields
        $('#dni, #address, #start-date, #rental-days').val('');
        $('#total-cost').val('');
        
        // Show modal
        const reservationModal = new bootstrap.Modal(document.getElementById('reservationModal'));
        reservationModal.show();
        
        // Reset modal state
        $('#reservation-form').show();
        $('#reservation-loading, #reservation-success').addClass('hide');
        $('#modal-footer-buttons').show();
      }
      
      // Calculate total cost
      $('#rental-days, #start-date').on('change input', function() {
        if (selectedVehicle && $('#rental-days').val()) {
          const days = parseInt($('#rental-days').val());
          const totalCost = days * selectedVehicle.pricePerDay;
          $('#total-cost').val(totalCost.toLocaleString('es-AR'));
        }
      });
      
      // Confirm reservation
      $('#confirm-reservation').click(function() {
        // Validate form
        if (!$('#reservation-form')[0].checkValidity()) {
          $('#reservation-form')[0].reportValidity();
          return;
        }
        
        // Get form data
        const reservationData = {
          vehicleId: selectedVehicle.id,
          vehicleModel: selectedVehicle.model,
          fullName: $('#fullname').val(),
          dni: $('#dni').val(),
          address: $('#address').val(),
          startDate: $('#start-date').val(),
          days: parseInt($('#rental-days').val()),
          totalCost: $('#total-cost').val().replace(/,/g, ''), // Remove commas for calculation
          paymentMethod: $('input[name="payment-method"]:checked').val(),
          userId: currentUser.email,
          timestamp: new Date().toISOString()
        };
        
        // Show loading
        $('#reservation-form').hide();
        $('#modal-footer-buttons').hide();
        $('#reservation-loading').removeClass('hide');
        
        // Simulate processing time
        setTimeout(function() {
          // Hide loading
          $('#reservation-loading').addClass('hide');
          
          // Show success
          $('#reservation-success').removeClass('hide');
          
          // Set summary details
          $('#summary-vehicle').text(selectedVehicle.model);
          $('#summary-date').text(new Date(reservationData.startDate).toLocaleDateString());
          $('#summary-days').text(reservationData.days);
          $('#summary-cost').text(reservationData.totalCost);
          $('#summary-payment').text(reservationData.paymentMethod);
          
          // Save reservation to localStorage
          let reservations = JSON.parse(localStorage.getItem('reservations')) || [];
          reservations.push(reservationData);
          localStorage.setItem('reservations', JSON.stringify(reservations));
        }, 1500);
      });
      
      // Make another reservation
      $('#make-another-reservation').click(function() {
        // Hide modal
        const reservationModal = bootstrap.Modal.getInstance(document.getElementById('reservationModal'));
        reservationModal.hide();
        
        // Redirect to fleet
        showSection('#fleet-section');
        populateVehicles();
      });
      
      // Initialize
      checkLoggedInUser();
      showSection('#home-section');
    });