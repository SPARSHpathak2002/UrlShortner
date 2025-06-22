function urlList() {
    return {
        urls: [],
        loading: false,
        inputUrl: '',
        fetchUrls() {
            this.loading = true;
            fetch('/api/dashboard/all')
                .then(res => res.json())
                .then(data => {
                    this.urls = data;
                    this.loading = false;
                })
                .catch(() => {
                    this.urls = [];
                    this.loading = false;
                });
        },
        generateUrl() {
            if (!this.inputUrl.trim()) return;
            fetch('/api/dashboard', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(this.inputUrl)
            })
                .then(res => {
                    if (res.ok) {
                        this.inputUrl = '';
                        this.fetchUrls();
                    }
                });
        },
        deleteUrl(shortenedUrl) {
            try {
                const urlObj = new URL(shortenedUrl);
                let id = urlObj.pathname.replace(/^\/+/, '');
                fetch(`/api/dashboard/${id}`, {
                    method: 'DELETE'
                })
                    .then(res => {
                        if (res.ok || res.status === 204) {
                            this.fetchUrls();
                        }
                    });
            } catch (e) {
                const id = shortenedUrl.split('/').pop();
                fetch(`/api/dashboard/${id}`, {
                    method: 'DELETE'
                })
                    .then(res => {
                        if (res.ok || res.status === 204) {
                            this.fetchUrls();
                        }
                    });
            }
        },
        copyUrl(shortenedUrl) {
            navigator.clipboard.writeText(shortenedUrl);
        },
    }
}