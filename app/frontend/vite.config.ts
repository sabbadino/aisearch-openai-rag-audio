import path from "path";
import react from "@vitejs/plugin-react";
import { defineConfig } from "vite";
//outbuild build C:\PRODUCT\repos\personal-external\personal\aisearch-openai-rag-audio-forked\app\backend\static
// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    build: {
        outDir: "../backend/static",
        emptyOutDir: true,
        sourcemap: true
    },
    resolve: {
        alias: {
            "@": path.resolve(__dirname, "./src")
        }
    },
    server: {
        proxy: {
            "/realtime": {
                target: "ws://localhost:8765",
                ws: true,
                rewriteWsOrigin: true
            }
        }
    }
});
