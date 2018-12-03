var app = new Vue({
    el: '#app',
    data: {
        message: '',
        recipients: '',
        subject: '',
    },
    methods: {
        SendMessage: function () {

            this.$http.post('/Notification/SendNotification', {
                message: this.message,
                recipients: this.recipients,
                subject: this.subject
            }).then(response => {
                alert(response.data);
            }, response => {
                alert(response.data);
            });
        }
    }
})